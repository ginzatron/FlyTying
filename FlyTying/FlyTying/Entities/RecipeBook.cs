using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class RecipeBook : EntityBase
    {
        public Guid AppUserId { get; set; }
        public IEnumerable<FlyRecipe> FlyRecipes { get; set; }
    }
}
