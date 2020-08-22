using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialOptionListValue : EntityBase
    {
        public string Value { get; set; } // orange
        // public MaterialOptionType ParentOptionType { get; set; } // color
    }
}

// i think this would repeate colors a bunch in the DB