using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Fly : BaseEntity
    {
        public string Name { get; set; }
        public FlyCategory FlyCategory { get; set; }
        public IEnumerable<FlyMaterial> FlyMaterials { get; set; } 
    }
}

// confusion about base entity. how do not use it and still haev generic repository
// still don't know how to load all navigational properties autoatically on an entity
