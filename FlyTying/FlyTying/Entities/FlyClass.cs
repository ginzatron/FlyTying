using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyClass
    {
        public string Name { get; set; }
        IEnumerable<TargetSpecies> TargetSpecies { get; set; }
    }
}
