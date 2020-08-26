using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyCategory : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<Fly> Flies { get; set; } // not sure if this is setup to navigate
    }
}
