using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Material : EntityBase
    {
        public string Name { get; set; }
        public MaterialCategory Category { get; set; }
        public IEnumerable<MaterialOption> ItemOptions { get; set; }
    }
}
