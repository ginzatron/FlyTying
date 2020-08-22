using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Hook : EntityBase, IMaterial
    {
        public MaterialCategory Category { get; set; } // Hook
        public MaterialOptionType OptionType { get; set; } // size
        public IEnumerable<FlyCategory> Categories { get;set; }
    }
}
