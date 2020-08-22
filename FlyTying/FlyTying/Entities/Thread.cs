using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Thread : EntityBase, IMaterial
    {
        public MaterialCategory Category { get; set; } // Thread
        public MaterialOptionType WeightOption { get; set; }
        public MaterialOptionType ColorOption { get; set; }
    }
}
