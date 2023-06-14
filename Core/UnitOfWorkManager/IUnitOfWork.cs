using DataAccess.Repositories;

namespace Core.UnitOfWorkManager;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : class;
}
