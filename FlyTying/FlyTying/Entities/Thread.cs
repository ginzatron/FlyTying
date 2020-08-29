using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Thread
    {
        public string Weight { get; set; }
        public string Denier { get; set; }
        public IEnumerable<string> ColorOptions { get; set; }
    }
}
