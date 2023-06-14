using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.UnitOfWorkManager;

public class UnitOfWork : IPersistenceUnitOfWork
{
    private readonly AppDbContext _context = new AppDbContext(new DbContextOptionsBuilder().Options);
    private readonly IRepositoryFactory _repositoryFactory;

    public UnitOfWork(IRepositoryFactory repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
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
