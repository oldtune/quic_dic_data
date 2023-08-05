using System.Linq.Expressions;
using Common.Models;

namespace Data.Repositories;
public interface IBaseRepository<T> where T : IDatabaseObject
{
    public Task<Result<None>> Add(T obj);
    public void Delete(T obj);
    public void Update(T obj);
    public Task<Result<None>> AddRange(IEnumerable<T> collection);
    public void DeleteRange(IEnumerable<T> collection);
    public void UpdateRange(IEnumerable<T> collection);
    public Task<IEnumerable<TResult>> QueryAsync<TResult>(Expression<Func<T, TResult>> selector = null, Expression<Func<T, bool>> filter = null);
    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public Task<T> FindAsync(object primaryKey);
    public Task<T> FindAsync(params object[] primaryKeys);
}