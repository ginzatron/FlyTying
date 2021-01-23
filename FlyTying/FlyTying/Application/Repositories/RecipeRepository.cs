using FlyTying.Application.Contexts;
using FlyTying.Application.Facet;
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

        public async Task<IEnumerable<Recipe>> matchHookClassification(IDictionary<string, string[]> facets) 
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
            return temp;
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
