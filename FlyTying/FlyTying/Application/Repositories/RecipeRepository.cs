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
            return _collection.AsQueryable().GroupBy(x => x.Hook.Classification)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .ToList()
                .ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }
    }
}
