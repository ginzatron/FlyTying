using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialSepcification : EntityBase
    {
        // this is a flattened MaterialOption with the selected value
        public string Title { get; set; } // color
        public string Value { get; set; } // yellow
    }
}
