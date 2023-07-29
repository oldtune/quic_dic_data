namespace Data.Repositories;
public interface IUnitOfWork
{
    public Task SaveChanges();
    public void Attach();
}