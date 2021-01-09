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

        public async Task<string> FacetSearch(string facet)
        {
            var options = new AggregateOptions()
            {
                AllowDiskUse = false,
                Collation = new Collation(
                "en_US"
            )};

            PipelineDefinition<Recipe, BsonDocument> temp = new BsonDocument[]
{
                new BsonDocument("$match",
                new BsonDocument("Hook.Classification", facet))
            };

            var aggregation = _collection.Aggregate(temp);
            return aggregation.Single().ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }

        public async Task<string> BuildHookFacets()
        {
            var options = new AggregateOptions()
            {
                AllowDiskUse = false,
                Collation = new Collation(
                "en_US"
            )};

            var pipeline = BuildPipeline();

            //var facetPipeline = AggregateFacet.Create("HookFacets", pipeline);
            var aggregation = _collection.Aggregate(pipeline, options);

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
