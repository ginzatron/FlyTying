using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    [BsonKnownTypes(typeof(Adhesive))]
    public class Supply
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
