using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyHook : EntityBase
    {
        public ItemCategory Category { get; set; }
        public Guid HookBaseId { get; set; }
        public IEnumerable<FlyItemOption> Options { get; set; }
        public FlyCategory FlyCategory { get; set; }
        public IEnumerable<FlyMaterial> FlyMaterials { get; set; }
    }
}
