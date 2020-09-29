using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Shank
    {
        public ShankLength Length { get; set; } // standard, long short
        public Modifier? Modifier { get; set; } // 1x,2x,3x
    }
}
