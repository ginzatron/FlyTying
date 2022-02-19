using Flies.Interfaces;
using Flies.RecipeDomain;
using MediatR;
using MongoDB.Driver;

namespace Flies.Queries;

public record GetRecipeListQuery() : IRequest<IEnumerable<Recipe>>;

public class GetRecipeListHandler : IRequestHandler<GetRecipeListQuery, IEnumerable<Recipe>>
{
    private readonly MongoDbContext _context;
    protected IMongoCollection<Recipe> _collection;

    public GetRecipeListHandler(MongoDbContext context)
    {
        _context = context;
        _collection = _context.GetCollection<Recipe>(typeof(Recipe).Name);
    }
    public async Task<IEnumerable<Recipe>> Handle(GetRecipeListQuery request, CancellationToken cancellationToken)
    {
        return await _collection.Find(Builders<Recipe>.Filter.Empty).ToListAsync();
    }
}
