using System.Linq.Expressions;
using Common.Models;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;
public class BaseRepository<T> : IBaseRepository<T> where T : class, IDatabaseObject
{
    readonly DictionaryDbContext _db;
    readonly DbSet<T> _set;
    public BaseRepository(DictionaryDbContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public async Task<Result<None>> Add(T obj)
    {
        Result<None>.FromTask(() => _set.AddAsync(obj));
    }

    public async Task AddRange(IEnumerable<T> collection)
    {
        await _set.AddRangeAsync(collection);
    }

    public void Delete(T obj)
    {
        _set.Remove(obj);
    }

    public void DeleteRange(IEnumerable<T> collection)
    {
        _set.RemoveRange(collection);
    }

    public async Task<Result<T>> FindAsync(object primaryKey)
    {
        return await Result._set.FindAsync(primaryKey);
    }

    public async Task<Result<T>> FindAsync(params object[] primaryKeys)
    {
        return await _set.FindAsync(primaryKeys);
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _set.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<TResult>> QueryAsync<TResult>(Expression<Func<T, TResult>> selector = null, Expression<Func<T, bool>> filter = null)
    {
        return await _set.Where(filter).Select(selector).ToListAsync();
    }

    public void Update(T obj)
    {
        _set.Attach(obj);
        _set.Entry(obj).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T> collection)
    {
        _set.AttachRange(collection);
        foreach (var entity in collection)
        {
            _set.Entry(entity).State = EntityState.Modified;
        }
    }
}