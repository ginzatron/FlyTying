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

    }
}
