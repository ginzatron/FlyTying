using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyRecipe : EntityBase
    {
        public string Name { get; set; }
        public Hook Hook { get; set; }
        public Thread Thread { get; set; } // could be a list?
        public Note Description { get; set; }
        public IEnumerable<Equipment> EquipmentList { get; set; }
        public IDictionary<FlySection,Ingredient> IngredientsList { get; set; }
        public IEnumerable<Adhesive> Adhesives { get; set; } // possibly equipment
        public IEnumerable<RecipeDirection> RecipeDirections { get; set; } // need to tie directions to sections and ingredients?
        public string DifficultyLevel { get; set; } // enum
        public IEnumerable<string> TargetFishSpecies { get; set; } // possible enum
        public string FlyClass { get; set; } // emerger, dry, nymph enum
        public string VideoUrl { get; set; }
    }
}

// ask a domain expert, are you usually completing the usage of an ingredient in one step?
// does the order of section/ingredient follow the order the fly is assembled?