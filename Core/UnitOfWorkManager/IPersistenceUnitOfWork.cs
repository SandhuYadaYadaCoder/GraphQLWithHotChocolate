namespace Core.UnitOfWorkManager;

public interface IPersistenceUnitOfWork : IUnitOfWork
{
    int SaveChanges();
    void BeginTransaction();
    void CommitTransaction();
    bool HasUnsavedChanges();
    void RollbackTransaction();
    Task<int> SaveChangesAsync();
}
