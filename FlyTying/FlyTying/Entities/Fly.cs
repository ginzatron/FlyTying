using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Fly : BaseEntity
    {
        public string Name { get; set; }
        public FlyCategory FlyCategory { get; set; }
        public IEnumerable<FlyMaterial> FlyMaterials { get; set; } 
    }
}
