using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyHook : EntityBase
    {
        public IEnumerable<string> SizeRange { get; set; }
        public FlyCategory FlyCategory { get; set; }
        public Hook BaseHook { get; set; }
    }
}
