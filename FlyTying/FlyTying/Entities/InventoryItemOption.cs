﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class InventoryItemOption
    {
        public Guid ItemOptionId { get; set; }
        public string Value { get; set; }

        // not sure if this needs the InventoryItem InventoryItem {get; set;} navigational property
    }
}
