﻿using FlyTying.Application.Contexts;
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
        private static readonly string[] _facets = {"Hook.Classification", "Pattern.PatternType", "Hook.Size"};

        public RecipeRepository(MongoRecipeDBContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<UpdatedFacetResults> GenerateFacets(IEnumerable<SearchFacet> selectedFacets)
        {
            var aggregate = _collection.Aggregate();
            var matchingFilter = BuildFilterFromFacets(selectedFacets); // you build a filter that looks for recipes in this filter, in this filter etc

            var matchResult = aggregate.Match(matchingFilter); // then you run that filter and get all the flies back that have that criteria

            var searchFacets = await GenerateSearchFacets(matchResult, selectedFacets);  // then you generate new faces based on that returned set of recipes

            var returnSet = new UpdatedFacetResults()
            {
                Recipes = matchResult.ToList(),
                Facets = searchFacets.ToList()
            };

            return returnSet;
        }

        private async Task<IEnumerable<SearchFacet>> GenerateSearchFacets(IAggregateFluent<Recipe> matchResult, IEnumerable<SearchFacet> selectedFacets)
        {
            var searechFacets = await matchResult.Facet(CreateFacet().ToArray()).ToListAsync();
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
        }

        // this is an actual mongo thing that returns all the different hook classifications or patter types that exist across all flies and how many of each
        // ex Egg(7), Tactucal(4)
        private IEnumerable<AggregateFacet<Recipe, AggregateSortByCountResult<string>>> CreateFacet()
        {
            foreach(var facet in _facets)
            {
                yield return AggregateFacet.Create(facet.Replace(".","_"), PipelineDefinition<Recipe, AggregateSortByCountResult<string>>.Create(new[]
                {
                    PipelineStageDefinitionBuilder.SortByCount<Recipe, string>($"${facet}")
                }));
            }
        }

        // Builds the filter that says, recipe in x classifcation or y pattern type
        private FilterDefinition<Recipe> BuildFilterFromFacets(IEnumerable<SearchFacet> facets)
        {
            var filter = Builders<Recipe>.Filter.Empty;


            var facetDictionary = (from facet in facets
                                   group facet.Title by facet.Group
                                   into dict
                                   select dict).ToDictionary(x => x.Key.Replace("_","."), x => x.ToArray());

            foreach(var keyValuePair in facetDictionary)
            {
                filter &= Builders<Recipe>.Filter.In(keyValuePair.Key, keyValuePair.Value);
            }
                               
            return filter;
        }
    }
}

