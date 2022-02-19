using Flies.RecipeDomain;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Flies.Queries;

public record GetRecipeByIdQuery(string id) : IRequest<Recipe>;

public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, Recipe>
{
    private readonly MongoDbContext _context;
    protected IMongoCollection<Recipe> _collection;

    public GetRecipeByIdQueryHandler(MongoDbContext context)
    {
        _context = context;
        _collection = _context.GetCollection<Recipe>(typeof(Recipe).Name);
    }
    public async Task<Recipe> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var filter = Builders<Recipe>.Filter.Eq("_id", ObjectId.Parse(request.id));
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}
