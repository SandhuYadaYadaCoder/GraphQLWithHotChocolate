using DataAccess;
using DataAccess.Repositories;

namespace Core.UnitOfWorkManager;

public class UnitOfWork : IPersistenceUnitOfWork, IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IRepositoryFactory _repositoryFactory;

    public UnitOfWork(AppDbContext context, IRepositoryFactory repositoryFactory)
    {
        _context = context;
        _repositoryFactory = repositoryFactory;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        return _repositoryFactory.Create<T>(_context);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public bool HasUnsavedChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}
