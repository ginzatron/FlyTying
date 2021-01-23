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

        public async Task<IEnumerable<Recipe>> matchHookClassification(string facet) // this will be an object with keys for facetTypes: array selected facets within that type
        {
            var facetAsEnumvalue = (HookClassification)Enum.Parse(typeof(HookClassification), facet);

            return _collection.Aggregate()
                .Match(x => x.Hook.Classification == facetAsEnumvalue).ToList();
        }

        public async Task<string> BuildHookFacets()
        {
            var typeFilter = Builders<Recipe>.Filter.Eq(x => (PatternType)x.Pattern.PatternType,  PatternType.Steelhead);
            var nameFilter = Builders<Recipe>.Filter.Eq(x => x.Name, "RoyalWulff");
            var temp = _collection.Aggregate().Match(nameFilter | typeFilter).ToList();


            return _collection.AsQueryable().GroupBy(x => x.Hook.Classification)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .ToList()
                .ToJson(new MongoDB.Bson.IO.JsonWriterSettings { Indent = true });
        }

        // the idea is to generate facets after matching stuff so you need facets for lots more fields because if you wany to search for flies that have a combination
        // of the materials you have, you'll be running a search with all of those as facets

        // build filters for each Facet
    }
}
