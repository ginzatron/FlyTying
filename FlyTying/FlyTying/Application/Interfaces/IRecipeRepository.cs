using FlyTying.Application.FacetSearch;
using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        Task<UpdateFacetResults> BuildHookFacets();
        Task<IEnumerable<Recipe>> CreateFilterFromFacets(IDictionary<string, string[]> facets);
    }
}
