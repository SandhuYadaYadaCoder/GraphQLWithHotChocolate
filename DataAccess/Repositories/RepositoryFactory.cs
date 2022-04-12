using DataAccess.Entities;

namespace DataAccess.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    public IRepository<T> Create<T>(AppDbContext context) where T : class
    {
        if (typeof(EntityBase) != typeof(T).BaseType)
        {
            throw new Exception("Trying to create repository of non entity base");
        }

        return new Repository<T>(context);
    }
}
