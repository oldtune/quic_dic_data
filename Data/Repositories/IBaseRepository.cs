using System.Linq.Expressions;

namespace Data.Repositories;
public interface IBaseRepository<T> where T : IDatabaseObject
{
    public void Add(T obj);
    public void Delete(T obj);
    public void Update(T obj);
    public void AddRange(IEnumerable<T> collection);
    public void DeleteRange(IEnumerable<T> collection);
    public void UpdateRange(IEnumerable<T> collection);
    public Task<IEnumerable<T>> QueryAsync<TResult>(Expression<Func<T, TResult>> seletor = null, Expression<Func<T, bool>> filter = null);
    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public Task<T> FindAsync(object primaryKey);
    public Task<T> FindAsync(params object[] primaryKeys);
}