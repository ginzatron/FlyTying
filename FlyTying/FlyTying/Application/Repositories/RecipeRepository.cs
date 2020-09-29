using FlyTying.Application.Contexts;
using FlyTying.Application.Interfaces;
using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Repositories
{
    public class RecipeRepository : MongoAsyncRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MongoRecipeDBContext context)
            : base(context)
        {
            // contract for other methods would come from IRecipeRepository
        }

        //private BsonDocument BuildFacetStage()
        //{

        //}

        private BsonElement BuildHookBucketStage()
        {
            return new BsonElement("HookClassification", new BsonArray
            {
                new BsonDocument("$bucket",
                    new BsonDocument
                    {
                        {"groupBy", "$Hook.Classification"},
                        {"default", "other"},
                        {
                            "output",
                            new BsonDocument("count",
                                new BsonDocument("$sum", 1))
                        }
                    })
            });
        }

        //private BsonElement BuildThreadStage()
        //{

        //}

        //private BsonElement BuildSuppliesStage()
        //{

        //}
    }
}
