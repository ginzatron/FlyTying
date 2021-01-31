using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class SearchFacet
    {
        public int Count { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public bool Selected { get; set; }
    }
}
