using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterial : EntityBase
    {
        // top two will be mapped from InventoryItem, won't need the category
        // do you need the id or just name? I think we do need the ID for editing purposed on the front so the user can
        // edit the material as an InventoryItem then when it's resaved it becomes a flymaterial again
        public string Name { get; set; }
        public Guid InventoryItemId { get; set; } 

        public FlyMaterialOption MaterialOption { get; set; }
        public FlyMaterialPosition Position { get; set; }
    }
}
