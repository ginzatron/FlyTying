using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialOptionType : EntityBase
    {
        public string Name { get; set; } // color, size, weight
        public IMaterial ParentMaterial { get; set; } // yarn
        public IEnumerable<MaterialOptionListValue> OptionsList { get; set; } 
    }
}
