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

        public virtual async Task<T> FindOneByFilterAsync(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).FirstOrDefaultAsync();

        public virtual async Task<T> FindByIdAsync(string id)
            => await _collection.Find<T>(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task CreateAsync(T document)
            => await _collection.InsertOneAsync(document);

        public virtual async Task UpdateAsync(string id, T document)
            => await _collection.ReplaceOneAsync<T>(x => x.Id == id, document);

        public virtual async Task DeleteByIdAsync(string id)
            =>await _collection.DeleteOneAsync<T>(x => x.Id == id);

        public virtual async Task DeleteByFilterAsync(Expression<Func<T, bool>> filter)
            => await _collection.DeleteOneAsync<T>(filter);

        public virtual async Task SoftDeleteAsync(string id, T document)
            => await UpdateAsync(id, document);
    }
}
