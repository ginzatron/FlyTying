using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialCategory : EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<Material> InventoryItems { get; set; }
    }

    // TODO or shoudl I have a base Category class or interface and inventorycategory inherits from it
    // there are potentially other categories in my application like a fly category, or a river category 
    // if it was an interface how would you know which category to inject?
    // or is it basically an enum and leave it as is?
}
