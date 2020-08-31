using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Equipment : EntityBase
    {
        public string Item { get; set; }
        public Note Note { get; set; }
    }
}
