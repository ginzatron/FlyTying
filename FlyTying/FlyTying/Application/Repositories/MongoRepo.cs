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
        private IMongoCollection<T> _collection;
        private readonly IFlyRecipeContext _context;

        public MongoRepo(IFlyRecipeContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name);
        }
        public virtual async Task<T> FindByIdAsync(string id)
            => await _collection.Find<T>(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task CreateAsync(T document)
            => await _collection.InsertOneAsync(document);
        
        public virtual async Task UpdateAsync(string id, T document)
            => await _collection.ReplaceOneAsync<T>(x => x.Id == id, document);
        
        public virtual async Task DeleteByIdAsync(string id)
            =>await _collection.DeleteOneAsync<T>(x => x.Id == id);
        
        public virtual async Task<IEnumerable<T>> Query(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).ToListAsync();

        public virtual async Task<IEnumerable<T>> Query()
            => await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
    }
}
