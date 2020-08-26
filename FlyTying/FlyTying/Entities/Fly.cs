using System;
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

// where to add specific brands in especially for hook

// CATEGORIES PROBLEM NEEDS TO BE SOLVED

// option Titles are size, weight, color etc maybe brand
// categories are yarn, hook, hackle etc