using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Hook : EntityBase
    {
        public string BrandName { get; set; }
        public string SizeRange { get; set; }
        public string Eye { get; set; }
        public string HookLength { get; set; }
        public string Wire { get; set; } 
        public string Gape { get; set; }
        public string Metal { get; set; }
        // wire gauge table/object, AWG or SWG size then diamter measurements
        //https://en.wikipedia.org/wiki/American_wire_gauge
    }
}
