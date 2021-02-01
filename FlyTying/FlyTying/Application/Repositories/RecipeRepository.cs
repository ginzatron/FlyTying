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

        public async Task<UpdatedFacetResults> GenerateFacets(IEnumerable<SearchFacet> selectedFacets)
        {
            var aggregate = _collection.Aggregate();
            var matchingFilter = BuildFilterFromFacets(selectedFacets);

            var matchResult = aggregate.Match(matchingFilter);

            var searchFacets = await GenerateSearchFacets(matchResult, selectedFacets);

            var returnSet = new UpdatedFacetResults()
            {
                Recipes = matchResult.ToList(),
                Facets = searchFacets
            };

            return returnSet;
        }

        private async Task<List<SearchFacet>> GenerateSearchFacets(IAggregateFluent<Recipe> matchResult, IEnumerable<SearchFacet> selectedFacets)
        {
            var hookFacet = CreateHookFacet();
            var patternFacet = CreatePatternFacet();
            var hookSizeFacet = CreateHookSizeFacet();

            var searechFacets = await matchResult.Facet(hookFacet, patternFacet, hookSizeFacet).ToListAsync();
            var x =  searechFacets.First().Facets.Select(x => new { Group = x.Name, Facets = x.Output<AggregateSortByCountResult<string>>() });

            var facetList = new List<SearchFacet>();

            foreach(var record in x)
            {
                var facet = record.Facets;
                foreach(var f in facet)
                {
                    var searchFacet = new SearchFacet()
                    {
                        Count = (Int32)f.Count,
                        Title = f.Id,
                        Group = record.Group,
                        Selected = false
                    };

                    if (selectedFacets.Any(x => x.Group == searchFacet.Group && x.Title == searchFacet.Title))
                        searchFacet.Selected = true;

                    facetList.Add(searchFacet);
                }
            }

            return facetList;
        }

        private AggregateFacet<Recipe, AggregateSortByCountResult<string>> CreatePatternFacet()
        {
            var patternFacet = AggregateFacet.Create("PatternNames",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Pattern.Name")
            }));

            return patternFacet;
        }

        private AggregateFacet<Recipe,AggregateSortByCountResult<string>> CreateHookFacet()
        {
            var hookFacet = AggregateFacet.Create("HookClassifications",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Hook.Classification")
            }));

            return hookFacet;
        }

        private AggregateFacet<Recipe, AggregateSortByCountResult<string>> CreateHookSizeFacet()
        {
            var hookFacet = AggregateFacet.Create("HookSizes",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Hook.Size")
            }));

            return hookFacet;
        }

        private FilterDefinition<Recipe> BuildFilterFromFacets(IEnumerable<SearchFacet> facets)
        {
            // this is not an elegant or efficient way to do this
            var filter = Builders<Recipe>.Filter.Empty;
            var facetDictionary = new Dictionary<string, List<string>>();

            foreach(var record in facets)
            {
                if (!facetDictionary.ContainsKey(record.Group))
                {
                    facetDictionary[record.Group] = new List<string>() { record.Title };
                }
                else
                {
                    facetDictionary[record.Group].Add(record.Title);
                }
            }

            if (facetDictionary.ContainsKey("PatternTypes"))
            {
                var patternArray = facetDictionary["PatternTypes"].Select(x => (PatternType)Enum.Parse(typeof(PatternType), x));
                var patternFilter = Builders<Recipe>.Filter.In(x => x.Pattern.PatternType, patternArray);
                filter &= patternFilter;
            }

            if (facetDictionary.ContainsKey("HookClassifications"))
            {
                var hookArray = facetDictionary["HookClassifications"].Select(x => (HookClassification)Enum.Parse(typeof(HookClassification), x));
                var hookClassFilter = Builders<Recipe>.Filter.In(x => x.Hook.Classification, hookArray);
                filter &= hookClassFilter;
            }

            if (facetDictionary.ContainsKey("PatternNames"))
            {
                var patternNameFilter = Builders<Recipe>.Filter.In(x => x.Pattern.Name, facetDictionary["PatternNames"]);
                filter &= patternNameFilter;
            }

            if (facetDictionary.ContainsKey("HookSizes"))
            {
                var hookSizeFilter = Builders<Recipe>.Filter.In(x => x.Hook.Size, facetDictionary["HookSizes"]);
                filter &= hookSizeFilter;
            }

            return filter;
        }
    }
}

