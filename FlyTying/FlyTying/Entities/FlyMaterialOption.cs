using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterialOption : EntityBase
    {
        public Guid InventoryItemOptionId { get; set; } // do you even need the id? how does this work with base entity?
        public string Discriminator { get; set; }
        public string Value { get; set; }

        public FlyMaterial ParentMaterial { get; set; }
    }
}
