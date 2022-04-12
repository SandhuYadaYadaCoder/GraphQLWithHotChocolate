namespace DataAccess.Repositories;

public interface IRepositoryFactory
{
    IRepository<T> Create<T>(AppDbContext context) where T : class;
}
