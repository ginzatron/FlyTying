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
            var sortByCount = new BsonElement("HookClassification", new BsonArray
                {
                    new BsonDocument
                    {
                        {"$sortByCount", "$Hook.Classification" }
                    }
                }
            );

            var facetState = new BsonDocument("$facet", new BsonDocument()
            {
                sortByCount
            });

            var pipeline = new[]
            {
                facetState
            };

            return _collection.Aggregate(PipelineDefinition<Recipe, BsonDocument>.Create(pipeline))
                .Single().ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }
    }
}
