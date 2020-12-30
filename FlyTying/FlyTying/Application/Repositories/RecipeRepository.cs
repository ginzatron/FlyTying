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

        public async Task<string> BuildHookFacets()
        {
            var options = new AggregateOptions()
            {
                AllowDiskUse = false,
                Collation = new Collation(
                "en_US"
            )};

            var pipeline = BuildPipeline();

            var facetPipeline = AggregateFacet.Create("HookFacets", pipeline);
            var aggregation = _collection.Aggregate(pipeline, options);

            return aggregation.Single().ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }

        private PipelineDefinition<Recipe, BsonDocument> BuildPipeline()
        {
             return new BsonDocument[]
             {
                new BsonDocument("$facet",new BsonDocument()
                        .Add("HookClassification", new BsonArray()
                                .Add(new BsonDocument()
                                        .Add("$sortByCount", "$Hook.Classification") // eq. "HookClassification": [{$sortByCount:"$Hook.Classification"}]
                                )
                        )
                        //.Add("Eye", new BsonArray()
                        //        .Add(new BsonDocument()
                        //                .Add("$sortByCount", "$Hook.Eye")
                        //        )
                        //)
                        //.Add("Shank", new BsonArray()
                        //        .Add(new BsonDocument()
                        //                .Add("$sortByCount", "$Hook.Shank")
                        //        )
                        //)
                        //.Add("Bend", new BsonArray()
                        //        .Add(new BsonDocument()
                        //                .Add("$sortByCount", "$Hook.Bend")
                        //        )
                        //)
                        //.Add("Gap", new BsonArray()
                        //        .Add(new BsonDocument()
                        //                .Add("$sortByCount", "$Hook.Gap")
                        //        )
                        //)
                        //.Add("Strength", new BsonArray()
                        //        .Add(new BsonDocument()
                        //                .Add("$sortByCount", "$Hook.Strength")
                        //        )
                        //)
                        )
              };
        }




        //private BsonElement BuildHookBucketStage()
        //{
        //    return new BsonElement("HookClassification", new BsonArray
        //    {
        //        new BsonDocument("$bucket",
        //            new BsonDocument
        //            {
        //                {"groupBy", "$Hook.Classification"},
        //                {"default", "other"},
        //                {
        //                    "output",
        //                    new BsonDocument("count",
        //                        new BsonDocument("$sum", 1))
        //                }
        //            })
        //    });
        //}
    }
}
