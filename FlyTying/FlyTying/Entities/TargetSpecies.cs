using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class TargetSpecies : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<FlyClass> TargetedFlies { get; set; }
    }
}
