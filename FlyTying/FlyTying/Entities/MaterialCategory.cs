using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialCategory : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<MaterialBase> Materials { get; set; }
    }
}
