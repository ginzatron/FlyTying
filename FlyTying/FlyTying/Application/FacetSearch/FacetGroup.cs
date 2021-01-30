using FlyTying.Application.FacetSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class FacetGroup
    {
        public string Title { get; set; }
        public SearechFacet[] Facets { get; set; }
    }
}
