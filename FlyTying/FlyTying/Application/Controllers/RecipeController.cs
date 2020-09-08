using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyTying.Application.Interfaces;
using FlyTying.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _repository.GetAll());
        }

    }
}
