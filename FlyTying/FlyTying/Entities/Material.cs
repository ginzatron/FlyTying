using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Material : EntityBase, IMaterial
    {
        public MaterialCategory Category { get; set; } // yarn, dubbing, flash
        public MaterialOptionType OptionType { get; set; } // color
    }
}

// optionType enum? : size, color
// could do a list of option types but i think thread is the only one with multiple option types
// made separate hook and thread classes because every fly needs them and their properties are slightly different