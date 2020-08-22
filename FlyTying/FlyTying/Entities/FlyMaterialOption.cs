using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterialOption : EntityBase
    {
        public Guid MaterialOptionType { get; set; } // do you even need the id? how does this work with base entity?
        public string Name { get; set; }
        public Guid MaterialOptionSelection { get; set; }
        public string MaterialOptionValue { get; set; }

        public FlyMaterial ParentFlyMaterial { get; set; }
    }
}
