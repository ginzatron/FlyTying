using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Strength
    {
        public HookStrength HookStrength { get; set; }
        public Modifier? Modifier { get; set; }
    }
}
