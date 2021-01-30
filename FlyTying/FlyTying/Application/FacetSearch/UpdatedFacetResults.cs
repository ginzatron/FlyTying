using FlyTying.Application.FacetSearch;
using FlyTying.Domain.Recipe;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.FacetSearch
{
    public class UpdatedFacetResults
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IList<FacetGroup> FacetGroups { get; set; }
    }
}
