using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Flies;

public class MongoDbContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration configuration)
    {
        _client = new MongoClient(configuration.GetSection("FlyRecipeDatabaseSettings:ConnectionString").Value);
        _db = _client.GetDatabase(configuration.GetSection("FlyRecipeDatabaseSettings:DatabaseName").Value);

        var enumConvention = new ConventionPack { new EnumRepresentationConvention(BsonType.String) };
        ConventionRegistry.Register("EnumString", enumConvention, type => true);
    }
    public IMongoCollection<T> GetCollection<T>(string collectionName)
        => _db.GetCollection<T>(collectionName);
}
