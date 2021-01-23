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

        // public method that then calls private method to create the SearchFilter
        // then calls private method to create the facets
        // then returns a document with the results of the filter and the new facets


        // method that searches base on filters
        // how to create an aggregation pipeline that returns the matched documents and the new facets based on those documents
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

            return await _collection.Aggregate().Match(filter).ToListAsync();
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
