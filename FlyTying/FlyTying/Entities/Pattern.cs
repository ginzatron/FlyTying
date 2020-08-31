using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Pattern : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<FlyRecipe> Flies { get; set; }
    }
}
