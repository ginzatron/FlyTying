﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Gap
    {
        public GapWidth Width { get; set; } // wide, narrow
        public Modifier? Modifier { get; set; } // 1x,2x,3x
    }
}
