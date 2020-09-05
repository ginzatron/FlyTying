using FlyTying.Application.Interfaces;
using FlyTying.Domain.Recipe;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlyTying.Application.Repositories
{
    public class MongoRepo<T> : IMongoRepo<T> where T: IDocument
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepo(IFlyRecipeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString); // you want to inject thi
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).FirstOrDefaultAsync();

        public virtual async Task<T> FindByIdAsync(string id)
        {
            var passedId = new ObjectId(id);
            return await _collection.Find<T>(x => x.Id == passedId).FirstOrDefaultAsync();
        }



    }
}
