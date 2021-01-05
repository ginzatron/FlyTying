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
        protected IMongoCollection<TDocument> _collection;
        private readonly MongoRecipeDBContext _context;

        public MongoAsyncRepository(MongoRecipeDBContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TDocument>(typeof(TDocument).Name);
        }

        public virtual async Task<IEnumerable<TDocument>> GetAll()
        {
            return await _collection.Find(Builders<TDocument>.Filter.Empty).Project<TDocument>("{Name: 1}").ToListAsync();
        }

        public virtual async Task<TDocument> GetByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(TDocument document)
        {
            document.CreatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(document);
        }
        
        public virtual async Task UpdateAsync(string id, TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id);

            document.ModifiedAt = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(filter, document, new ReplaceOptions() { IsUpsert = true});
        }
        
        public virtual async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id);

            await _collection.DeleteOneAsync(filter);
        }
        
        public virtual async Task<IEnumerable<TDocument>> Query(Expression<Func<TDocument, bool>> filter)
            => await _collection.Find(filter).ToListAsync();
    }
}
