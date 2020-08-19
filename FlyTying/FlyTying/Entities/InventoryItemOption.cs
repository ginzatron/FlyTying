﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class InventoryItemOption
    {
        public Guid ItemOptionId { get; set; }
        public string Discriminator { get; set; } // size, color, weight etc. Should this be it's own class ItemOptionCategory?
        public string Value { get; set; }

        // not sure if this needs the InventoryItem InventoryItem {get; set;} navigational property
    }
}
