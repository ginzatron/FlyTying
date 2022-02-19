using Flies.RecipeDomain;
using MediatR;
using MongoDB.Driver;

namespace Flies.Commands;

public record CreateRecipeCommand(Recipe recipe) : IRequest<Task>;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Task>
{
    private readonly MongoDbContext _context;
    protected IMongoCollection<Recipe> _collection;

    public CreateRecipeCommandHandler(MongoDbContext context)
    {
        _context = context;
        _collection = _context.GetCollection<Recipe>(typeof(Recipe).Name);
    }
    public Task<Task> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        request.recipe.CreatedAt = DateTime.UtcNow;
        return Task.FromResult(_collection.InsertOneAsync(request.recipe));
    }
}


