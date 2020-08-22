using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterial : EntityBase
    {
        public string Name { get; set; }
        public Guid MaterialId { get; set; } 

        public FlyMaterialOption MaterialOption { get; set; }
        public FlyMaterialPosition Position { get; set; }
    }
}
