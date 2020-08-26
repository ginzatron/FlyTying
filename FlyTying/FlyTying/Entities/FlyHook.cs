using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyHook : EntityBase
    {
        public Guid HookBaseId { get; set; }
        public IEnumerable<FlyItemOption> HookOptions { get; set; } // will set, size, fly category wet or nymph etc, and brand?
        public IEnumerable<FlyMaterial> FlyMaterials { get; set; }
    }
}
