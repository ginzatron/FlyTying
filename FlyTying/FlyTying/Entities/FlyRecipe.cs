using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyRecipe : EntityBase
    {
        public string Name { get; set; }
        public Guid AppUserId { get; set; }
        public Hook Hook { get; set; }
        public IEnumerable<Thread> Threads { get; set; }
        public Note Description { get; set; }
        public IEnumerable<Equipment> EquipmentList { get; set; }
        public IDictionary<FlySection,Ingredient[]> IngredientsList { get; set; }
        public IEnumerable<Adhesive> Adhesives { get; set; } // maybe under IEquipment
        public IEnumerable<RecipeDirection> RecipeDirections { get; set; }
        public string DifficultyLevel { get; set; } // enum
        public IEnumerable<TargetSpecies> TargetFishSpecies { get; set; } // species are going to be filtered by other recipe choices you've made
        public FlyClass FlyClass { get; set; } // emerger, dry, nymph . should be a class
        public string VideoUrl { get; set; }
    }
}

// ask a domain expert, are you usually completing the usage of an ingredient in one step?
// does the order of section/ingredient follow the order the fly is assembled?