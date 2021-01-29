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

        // public method that then calls private method to create the SearchFilter
        // then calls private method to create the facets
        // then returns a document with the results of the filter and the new facets


        // method that searches base on filters
        // how to create an aggregation pipeline that returns the matched documents and the new facets based on those documents

        public void doEVeryting()
        {
            //buil filter
            //build facets
            //var temp = await _collection.Aggregate()
            //    .Match(RETURN_FILTER)
            //    .Facet(projectFacet, hookFacet, patternFacet)
            //    .ToListAsync();

            // CREATE RETURN OBJECT
        }
        public async Task<IEnumerable<Recipe>> CreateFilterFromFacets(IDictionary<string, string[]> facets)
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


            var temp = await _collection.Aggregate().Match(filter).ToListAsync();

            // I want to do the match then facets where one facet is a projection of the docs and the other facets are creating new search facets
            return temp;
        }

        public async Task<UpdateFacetResults> BuildHookFacets()
        {
            //method to return facetStages
            //method to build pipelines from those stages called in above method


            //var sortByCountHook = PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Hook.Classification");
            //var sortByCountPattern = PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("Pattern.Name");

            //var pipeline1 = PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new IPipelineStageDefinition[] { sortByCountHook});
            //var pipeline2 = PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new IPipelineStageDefinition[] { sortByCountPattern });

            //var facetPipeline1 = AggregateFacet.Create("pipe1", pipeline1);
            //var facetPipeline2 = AggregateFacet.Create("pipe2", pipeline2);

            var hookFacet = AggregateFacet.Create("HookCount",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Hook.Classification")
            }));

            var patternFacet = AggregateFacet.Create("PatternCount",
            PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
            {
                PipelineStageDefinitionBuilder.SortByCount<Recipe, string>("$Pattern.Name")
            }));

            var projectFacet = AggregateFacet.Create("ProjectFacet",
                PipelineDefinition<Recipe, Projection>.Create(new[]
                {
                    PipelineStageDefinitionBuilder.Project<Recipe, Projection>(x => new Projection { Name = x.Name, num = x.Id})
             }));

            var temp =  await _collection.Aggregate()
                .Match(Builders<Recipe>.Filter.Empty)
                .Facet(projectFacet, hookFacet, patternFacet)
                .ToListAsync();


            var flyList = temp.First().Facets.First(x => x.Name == "ProjectFacet").Output<Projection>().ToList();
            
            var hookReturn = temp.First().Facets.Where(x => x.Name == "HookCount").Select(x => new FacetGroup
            {
                Title = x.Name,
                Facets = x.Output<AggregateSortByCountResult<string>>()
                    .Select(x => new FacetItem { Id = x.Id, Count = (Int32)x.Count }).ToArray()
            }).FirstOrDefault();

            var patternReturn = temp.First().Facets.Where(x => x.Name == "PatternCount").Select(x => new FacetGroup
            {
                Title = x.Name,
                Facets = x.Output<AggregateSortByCountResult<string>>()
                    .Select(x => new FacetItem { Id = x.Id, Count = (Int32)x.Count }).ToArray()
            }).FirstOrDefault();

            var returnSet = new UpdateFacetResults() 
            {
                FlyList = flyList,
                FacetGroups = new List<FacetGroup>() { hookReturn, patternReturn}
            };

            return returnSet;
        }
    }
}

