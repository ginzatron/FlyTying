using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class InventoryItemOption : BaseEntity
    {
        public string Discriminator { get; set; } // size, color, weight etc. Should this be it's own class ItemOptionCategory?
        public string Value { get; set; }
    }
}
