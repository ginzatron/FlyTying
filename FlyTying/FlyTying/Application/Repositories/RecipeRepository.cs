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
        public RecipeRepository(IMongoFlyRecipeDBContext context)
            : base(context)
        {

        }
    }
}
