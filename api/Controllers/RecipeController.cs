using Flies.Commands;
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
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetRecipeListQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetRecipeByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public Task Create([FromBody]Recipe recipe)
    {
        var cmd = new CreateRecipeCommand(recipe);
        return _mediator.Send(cmd);
    }
}
