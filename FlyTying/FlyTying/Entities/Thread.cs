using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Thread
    {
        public string Weight { get; set; }
        public string Denier { get; set; } // more accurate weight measure, weight in grams of 9k meters of thread
        public string BreakingStrenth { get; set; } // in oz. don't see that much
        public string Fiber { get; set; } // nylon, silk, polyester, kevlar, GSP? most people use nylon or heavier polyester
        public bool Waxed { get; set; } // everything except, silk kevlar and GSP come waxed
        public string Configuration { get; set; } // round or flat
        public IEnumerable<string> ColorOptions { get; set; }
    }
}
