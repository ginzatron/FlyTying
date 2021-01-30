using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class SearechFacet
    {
        public int Count { get; set; }
        public string Id { get; set; }
    }
}
