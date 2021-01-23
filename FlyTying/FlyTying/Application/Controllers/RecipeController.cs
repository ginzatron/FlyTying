using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FlyTying.Application.Interfaces;
using FlyTying.Application.Repositories;
using FlyTying.Domain.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;

namespace FlyTying.Application.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repository;

        public RecipeController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes(string facet)
        {
            // should take parameter with default value and both go to the same search?
            // override GetAll
            //if (facet != null)
            //{
            //    var result = await _repository.matchHookClassification(facet);
            //    return Ok(result);
            //}
            var recipes = await _repository.GetAll();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(string id)
        {
            var recipe = await _repository.GetByIdAsync(id);
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            await _repository.CreateAsync(recipe);
            return CreatedAtAction("GetRecipes", new { id = recipe.Id }, recipe);
        }   

        [HttpPut]
        public async Task<IActionResult> UpdateRecipe(string id, Recipe recipe)
        {
            await _repository.UpdateAsync(id, recipe);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpGet("facet")] 
        public async Task<IActionResult> BuildHookFacets()
        {
            var facetList = new Dictionary<string, string[]>();
            facetList["patterns"] = new string[] { "Steelhead", "Hopper" };
            facetList["patternNames"] = new string[] { "RibHaresEar2", "RoyalWulff1" };
            facetList["hookClassification"] = new string[] { "Nymph", "Jig" };

            var result = await _repository.matchHookClassification(facetList);
            return Ok(result);
        }
    }
}
