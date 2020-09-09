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
    [Route("api/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repository;

        public RecipeController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _repository.GetAll();
            return Ok(recipes);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            await _repository.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
