using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        Task<string> BuildHookFacets();
        Task<string> matchHookClassification(string facet);
    }
}
