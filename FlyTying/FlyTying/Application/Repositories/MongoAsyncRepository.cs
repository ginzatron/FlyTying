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
    public abstract class MongoAsyncRepository<T> : IAsyncRepository<T> where T: IDocument
    {
        private IMongoCollection<T> _collection;
        private readonly IMongoFlyRecipeDBContext _context;

        public MongoAsyncRepository(IMongoFlyRecipeDBContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name); // i don't think i want to set this like this
        }
        public virtual async Task<T> FindByIdAsync(string id)
            => await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

        public virtual async Task CreateAsync(T document)
            => await _collection.InsertOneAsync(document);
        
        public virtual async Task UpdateAsync(string id, T document)
            => await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", document.Id), document);
        
        public virtual async Task DeleteByIdAsync(string id)
            =>await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        
        public virtual async Task<IEnumerable<T>> Query(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).ToListAsync();

        public virtual async Task<IEnumerable<T>> Query()
            => await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
    }
}
