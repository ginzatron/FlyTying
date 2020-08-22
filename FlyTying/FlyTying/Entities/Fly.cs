using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Fly : EntityBase
    {
        public string Name { get; set; }
        public AppUser User { get; set; }
        public FlyCategory FlyCategory { get => FlyHook.FlyCategory;}
        public FlyHook FlyHook { get; set; }
        public FlyThread FlyThread { get; set; }
        public IEnumerable<FlyMaterial> FlyMaterials { get; set; } 
    }
}
// TODO have materials save in a tying order, sort order?