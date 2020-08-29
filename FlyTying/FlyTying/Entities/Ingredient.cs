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
        public int BuildStep { get; set; }
        public Adhesive Adhesive { get; set; } // thread, glue, cement
        public Note Instruction { get; set; }
    }
}
