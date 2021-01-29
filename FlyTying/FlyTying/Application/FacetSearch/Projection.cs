using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class Projection
    {
        public string Name { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string num { get; set; }
    }
}
