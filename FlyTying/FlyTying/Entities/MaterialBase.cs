using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class MaterialBase : EntityBase, IItemBase
    {
        public ItemCategory Category { get; set; }
        public IEnumerable<BaseOption> BaseOptions { get; set; }
    }
}