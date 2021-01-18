using FlyTying.Application.Contexts;
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

        public async Task<IEnumerable<Recipe>> matchHookClassification(string facet)
        {
            var facetAsEnumvalue = (HookClassification)Enum.Parse(typeof(HookClassification), facet);

            return _collection.Aggregate()
                .Match(x => x.Hook.Classification == facetAsEnumvalue).ToList();
        }

        public async Task<string> BuildHookFacets()
        {
            // need to make a Facet class that gets returned as a list of Facets and return that aggregation step as opposed to aggregation.Single...
            var options = new AggregateOptions()
            {
                AllowDiskUse = false,
                Collation = new Collation(
                "en_US"
            )};

            var pipeline = BuildPipeline();

            //var facetPipeline = AggregateFacet.Create("HookFacets", pipeline);
            var aggregation =  await _collection.Aggregate(pipeline, options).ToListAsync();

            return aggregation.Single().ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }

        private PipelineDefinition<Recipe, BsonDocument> BuildPipeline()
        {
             return new BsonDocument[]
             {
                new BsonDocument("$facet",new BsonDocument()
                        .Add("HookClassification", new BsonArray()
                                .Add
                                (
                                    new BsonDocument().Add("$sortByCount", "$Hook.Classification") // eq. "HookClassification": [{$sortByCount:"$Hook.Classification"}]
                                )
                            )
                        )
              };
        }
    }
}
