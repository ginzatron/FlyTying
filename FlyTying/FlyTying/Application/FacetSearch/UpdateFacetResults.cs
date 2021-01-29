using FlyTying.Application.FacetSearch;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class UpdateFacetResults
    {
        public IEnumerable<Projection> FlyList { get; set; }
        public IList<FacetGroup> FacetGroups { get; set; }
    }
}
