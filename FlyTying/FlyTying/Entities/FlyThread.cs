using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyThread : EntityBase
    {
        public string Color { get; set; }
        public string Weight { get; set; }
        public Thread BaseThread { get; set; }
    }
}
