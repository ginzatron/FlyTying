using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterial : EntityBase
    {
        public string Category { get; set; }
        public Guid MaterialBaseId { get; set; } 
        public IEnumerable<FlyItemOption> Options { get; set; }
        public HookPosition Position { get; set; }
    }
}
