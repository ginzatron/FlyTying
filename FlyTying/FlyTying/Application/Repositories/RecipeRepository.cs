using FlyTying.Application.Contexts;
using FlyTying.Application.FacetSearch;
using FlyTying.Application.Interfaces;
using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Repositories
{
    public class RecipeRepository : MongoAsyncRepository<Recipe>, IRecipeRepository
    {
        private readonly MongoRecipeDBContext _context;
        private static readonly string[] _facets = {"Hook.Classifiacation", "Pattern.PatternType", "HookSizes"};

        public RecipeRepository(MongoRecipeDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<UpdatedFacetResults> GenerateFacets(IEnumerable<SearchFacet> selectedFacets)
        {
            var aggregate = _collection.Aggregate();
            var matchingFilter = BuildFilterFromFacets(selectedFacets);

            var matchResult = aggregate.Match(matchingFilter);

            var searchFacets = await GenerateSearchFacets(matchResult, selectedFacets);

            var returnSet = new UpdatedFacetResults()
            {
                Recipes = matchResult.ToList(),
                Facets = searchFacets.ToList()
            };

            return returnSet;
        }

        private async Task<IEnumerable<SearchFacet>> GenerateSearchFacets(IAggregateFluent<Recipe> matchResult, IEnumerable<SearchFacet> selectedFacets)
        {
            var searechFacets = await matchResult.Facet(CreateFacet().ToList()).ToListAsync();
            var results =  searechFacets.First().Facets.Select(x => new { Group = x.Name, Facets = x.Output<AggregateSortByCountResult<string>>() });

            return from result in results
                    from facet in result.Facets
                    select 
                    (new SearchFacet { 
                        Count = (Int32)facet.Count, 
                        Title = facet.Id, 
                        Group = result.Group, 
                        Selected = (selectedFacets.Any(x => x.Group == result.Group && x.Title == facet.Id))
                    });


    
                    
            //var facetList = new List<SearchFacet>();

            //foreach (var record in results)
            //{
            //    var facet = record.Facets;
            //    foreach (var f in facet)
            //    {
            //        var searchFacet = new SearchFacet()
            //        {
            //            Count = (Int32)f.Count,
            //            Title = f.Id,
            //            Group = record.Group,
            //            Selected = false
            //        };

            //        if (selectedFacets.Any(x => x.Group == searchFacet.Group && x.Title == searchFacet.Title))
            //            searchFacet.Selected = true;

            //        facetList.Add(searchFacet);
            //    }
            //}

            //return facetList;
        }

        private IEnumerable<AggregateFacet<Recipe, AggregateSortByCountResult<string>>> CreateFacet()
        {
            foreach(var facet in _facets)
            {
                yield return AggregateFacet.Create(facet, PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
                {
                    PipelineStageDefinitionBuilder.SortByCount<Recipe, string>($"${facet}")
                }));
            }
        }
        private FilterDefinition<Recipe> BuildFilterFromFacets(IEnumerable<SearchFacet> facets)
        {
            var filter = Builders<Recipe>.Filter.Empty;


            var facetDictionary = (from facet in facets
                                   group facet.Title by facet.Group
                                   into dict
                                   select dict).ToDictionary(x => x.Key, x => x.ToArray());

            foreach(var keyValuePair in facetDictionary)
            {
                filter &= Builders<Recipe>.Filter.In(keyValuePair.Key, keyValuePair.Value);
            }
                               
            return filter;
        }

        //mapping class => dictionary <facetGroup, enum type and property path>
        // 
    }
}

