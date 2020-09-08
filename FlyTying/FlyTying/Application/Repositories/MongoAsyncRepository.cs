using FlyTying.Application.Contexts;
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
    public class MongoAsyncRepository<TDocument> : IAsyncRepository<TDocument> where TDocument : IDocument
    {
        private IMongoCollection<TDocument> _collection;
        private readonly MongoRecipeDBContext _context;

        public MongoAsyncRepository(MongoRecipeDBContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TDocument>(typeof(TDocument).Name); // i don't think i want to set this like this
        }

        public virtual async Task<IEnumerable<TDocument>> GetAll()
            => await _collection.Find(FilterDefinition<TDocument>.Empty).ToListAsync();

        public virtual async Task<TDocument> GetByIdAsync(string id)
            => await _collection.Find(Builders<TDocument>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

        public virtual async Task CreateAsync(TDocument document)
            => await _collection.InsertOneAsync(document);
        
        public virtual async Task UpdateAsync(string id, TDocument document)
            => await _collection.ReplaceOneAsync(Builders<TDocument>.Filter.Eq("_id", document.Id), document);
        
        public virtual async Task DeleteByIdAsync(string id)
            =>await _collection.DeleteOneAsync(Builders<TDocument>.Filter.Eq("_id", id));
        
        public virtual async Task<IEnumerable<TDocument>> Query(Expression<Func<TDocument, bool>> filter)
            => await _collection.Find(filter).ToListAsync();
    }
}
