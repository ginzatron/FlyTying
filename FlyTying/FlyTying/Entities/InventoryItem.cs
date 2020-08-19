using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; }
        public InventoryCategory Category { get; set; }
        public IEnumerable<InventoryItemOption> ItemOptions { get; set; }
    }
}
