using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public interface IMaterialBase
    {
        MaterialCategory Category { get; set; }
        IEnumerable<BaseOption> BaseOptions { get; set; }
    }
}
