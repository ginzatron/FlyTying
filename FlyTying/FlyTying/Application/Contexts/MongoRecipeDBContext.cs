using FlyTying.Application.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Contexts
{
    public class MongoRecipeDBContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;

        public MongoRecipeDBContext(IOptions<FlyRecipeDatabaseSettings> config)
        {
            _client = new MongoClient(config.Value.ConnectionString);
            _db = _client.GetDatabase(config.Value.DatabaseName);

            var enumConvention = new ConventionPack { new EnumRepresentationConvention(BsonType.String) };
            ConventionRegistry.Register("EnumString", enumConvention, type => true);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
            => _db.GetCollection<T>(collectionName);
    }
}
