using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class HookBase : EntityBase, IItemBase
    {
        public ItemCategory Category { get; set; }
        public IEnumerable<BaseOption> BaseOptions { get; set; } // maybe a FlyBaseOption?

        // put the fly category here? dry, nymph etc?
        // instead of using an interface should material and hook inherit from ItemBase
    }
}
