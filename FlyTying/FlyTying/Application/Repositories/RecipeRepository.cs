using FlyTying.Application.Contexts;
using FlyTying.Application.FacetSearch;
using FlyTying.Application.Interfaces;
using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Repositories
{
    public class RecipeRepository : MongoAsyncRepository<Recipe>, IRecipeRepository
    {
        private readonly MongoRecipeDBContext _context;

        public RecipeRepository(MongoRecipeDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<UpdatedFacetResults> GenerateFacets(IDictionary<string, string[]> facets)
        {
            var aggregate = _collection.Aggregate();
            var matchingFilter = BuildFilterFromFacets(facets);

            var matchResult = aggregate.Match(matchingFilter);

            var searchFacets = await GenerateSearchFacets(matchResult);

            var returnSet = new UpdatedFacetResults()
            {
                Recipes = matchResult.ToList(),
                FacetGroups = searchFacets
            };

            return returnSet;
        }

        private async Task<List<FacetGroup>> GenerateSearchFacets(IAggregateFluent<Recipe> matchResult)
        {
            var hookFacet = CreateHookFacet();
            var patternFacet = CreatePatternFacet();

            var searechFacets = await matchResult.Facet(hookFacet, patternFacet).ToListAsync();
            return searechFacets.First().Facets.Select(x => new FacetGroup
            {
                Title = x.Name,
                Facets = x.Output<AggregateSortByCountResult<string>>()
                .Select(x => new SearechFacet { Id = x.Id, Count = (Int32)x.Count }).ToArray()
            }).ToList();
        }

        private AggregateFacet<Recipe, AggregateSortByCountResult<string>> CreatePatternFacet()
        {
            var patternFacet = AggregateFacet.Create("PatternCount",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Pattern.Name")
            }));

            return patternFacet;
        }

        private AggregateFacet<Recipe,AggregateSortByCountResult<string>> CreateHookFacet()
        {
            var hookFacet = AggregateFacet.Create("HookCount",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Hook.Classification")
            }));

            return hookFacet;
        }

        private FilterDefinition<Recipe> BuildFilterFromFacets(IDictionary<string, string[]> facets)
        {
            var filter = Builders<Recipe>.Filter.Empty;

            if (facets.ContainsKey("patterns"))
            {
                var patternArray = facets["patterns"].Select(x => (PatternType)Enum.Parse(typeof(PatternType), x));
                var patternFilter = Builders<Recipe>.Filter.In(x => x.Pattern.PatternType, patternArray);
                filter &= patternFilter;
            }

            if (facets.ContainsKey("hookClassification"))
            {
                var hookArray = facets["hookClassification"].Select(x => (HookClassification)Enum.Parse(typeof(HookClassification), x));
                var hookClassFilter = Builders<Recipe>.Filter.In(x => x.Hook.Classification, hookArray);
                filter &= hookClassFilter;
            }

            if (facets.ContainsKey("patternNames"))
            {
                var patternNameFilter = Builders<Recipe>.Filter.In(x => x.Pattern.Name, facets["patternNames"]);
                filter &= patternNameFilter;
            }

            return filter;
        }
    }
}

