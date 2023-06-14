namespace Core.UnitOfWorkManager;

public interface IPersistenceUnitOfWork : IUnitOfWork
{
    int SaveChanges();
    bool HasUnsavedChanges();
    Task<int> SaveChangesAsync();
}
