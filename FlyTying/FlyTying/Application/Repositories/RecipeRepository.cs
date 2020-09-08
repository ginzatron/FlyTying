using FlyTying.Application.Contexts;
using FlyTying.Application.Interfaces;
using FlyTying.Domain.Recipe;
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
    }
}
