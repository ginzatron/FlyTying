using FlyTying.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        // place methods unique to Recipe that don't fit in the generic repo
    }
}
