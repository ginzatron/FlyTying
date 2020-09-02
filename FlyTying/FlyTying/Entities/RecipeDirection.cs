using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class RecipeDirection
    {
        public int StepNumber { get; set; }
        public Image Image { get; set; }
        public Guid FlySectionId { get; set; }
        public IEnumerable<Guid> NeededIngredients { get; set; }
        public Guid AdhesiveId { get; set; }
        public Note Instruction { get; set; }

    }
}
