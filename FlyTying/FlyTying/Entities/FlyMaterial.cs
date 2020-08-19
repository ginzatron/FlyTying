using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterial : BaseEntity
    {
        public string Name { get; set; }
        public Guid InventoryItemId { get; set; } // do you need the id or just name?
        public FlyMaterialOption MaterialOption { get; set; }
    }
}
