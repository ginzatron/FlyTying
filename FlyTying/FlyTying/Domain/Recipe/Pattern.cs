using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Pattern
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<Section,Material[]> Anatomy { get; set; }
        public IEnumerable<Species> Targets { get; set; }
        public Classification Classification { get; set; } 
    }
}

// ask a domain expert, are you usually completing the usage of an ingredient in one step?
// does the order of section/ingredient follow the order the fly is assembled?