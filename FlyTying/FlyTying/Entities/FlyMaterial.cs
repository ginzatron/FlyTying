using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyMaterial : EntityBase
    {
        public string MaterialCategory { get; set; } // yarn
        public Guid MaterialBaseId { get; set; } //id
        public IEnumerable<FlyItemOption> Options { get; set; } // 
        public string Position { get; set; }  // abdomen, or is position an option with title position and value abdomen
    }
}
