using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public interface IMaterial
    {
        MaterialCategory Category { get; set; }
    }
}
