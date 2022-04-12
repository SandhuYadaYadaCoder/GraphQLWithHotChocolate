using DataAccess.Repositories;

namespace Core.UnitOfWorkManager;

public interface IUnitOfWork : IDisposable
{
    bool HasUnsavedChanges();
    IRepository<T> GetRepository<T>() where T : class;
}
