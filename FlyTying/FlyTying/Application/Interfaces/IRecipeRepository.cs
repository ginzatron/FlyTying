using FlyTying.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IRecipeRepository : IAsyncRepository<Recipe>
    {
        // not sure why i need the IAsyncRepo when RecipeRepo already inherits from MogoAsync which inherits from IAsyncRepo
        // i guess if you wanted a different implementation of the IAsyncRepo different than MongoAsyncRepo
        // place methods unique to Recipe that don't fit in the generic repo
    }
}
