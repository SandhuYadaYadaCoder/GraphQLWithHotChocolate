namespace Core.UnitOfWorkManager;

public interface IPersistenceUnitOfWork
{
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
