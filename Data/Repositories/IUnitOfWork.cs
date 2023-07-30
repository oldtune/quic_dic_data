
using Common.Models;

namespace Data.Repositories;
public interface IUnitOfWork
{
    public Task<Result<None>> SaveChanges();
    public void Attach();
}