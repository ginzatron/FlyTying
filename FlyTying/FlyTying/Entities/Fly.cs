﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Fly : EntityBase
    {
        public string Name { get; set; }
        public AppUser User { get; set; }
        public FlyHook Hook { get; set; }
    }
}
// TODO have materials save in a tying order, sort order?
// idea: Maybe the fly is just a name and it has a hook on and that's where al the materials reside so you could
// have fly variations?

// where to add specific brands in especially for hook

// what to do with all the categories