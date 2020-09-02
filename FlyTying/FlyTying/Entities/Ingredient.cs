using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Ingredient : EntityBase
    {
        public string MaterialCategory { get; set; } // yarn
        public Guid MaterialBaseId { get; set; } //id
        public IEnumerable<IngredientSepcification> Options { get; set; } // 
        public Note Note { get; set; }
        public Ingredient SubstituteIngredient { get; set; }
    }
}
