using Flies.Queries;
using Flies.RecipeDomain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IMediator _mediator;
    public RecipeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IEnumerable<Recipe>> Get()
    {
        return await _mediator.Send(new GetRecipeListQuery());
    }
    [HttpGet("{id}")]
    public async Task<Recipe> GetById(string id)
    {
        return await _mediator.Send(new GetRecipeByIdQuery(id));
    }
}
