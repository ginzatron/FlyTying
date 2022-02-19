using System.Linq.Expressions;

namespace Flies.Interfaces;

public interface IAsyncRepository<T> where T : IDocument
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetByIdAsync(string id);
    Task CreateAsync(T document);
    Task UpdateAsync(string id, T document);
    Task DeleteByIdAsync(string id);
    Task<IEnumerable<T>> Query(Expression<Func<T, bool>> filter);
}
