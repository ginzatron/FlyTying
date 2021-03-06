﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class ItemCategory : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<IItemBase> Items { get; set; }
    }
}
