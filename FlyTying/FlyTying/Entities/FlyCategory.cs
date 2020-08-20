using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyCategory : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Fly> Flies { get; set; }
    }
}
