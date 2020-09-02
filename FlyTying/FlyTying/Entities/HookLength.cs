using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class HookLength
    {
        public string Modifer { get; set; } // 1x,2x,3x, modifer should be an enum or class?
        public bool IsStandard { get; set; }
        public bool IsLong { get; set; }
        public bool IsShort { get; set; }
    }
}
