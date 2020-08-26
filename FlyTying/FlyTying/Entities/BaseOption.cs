using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class BaseOption : EntityBase
    {
        public string Title { get; set; }
        public IEnumerable<BaseOptionValue> OptionValuesList { get; set; } 
    }
}
