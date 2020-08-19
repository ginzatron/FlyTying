using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterialOption : BaseEntity
    {
        public Guid InventoryItemOptionId { get; set; } // do you even need the id?
        public string Value { get; set; }
    }
}
