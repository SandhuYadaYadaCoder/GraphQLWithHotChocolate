using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DataAccess;

public static class DatabaseAutoMigrations
{
    public static IServiceProvider UpdateDatabase(
        this IServiceProvider serviceProvider,
        ILogger logger)
    {
        try
        {
            logger.Information("Run EFCore migrations, if any");
            using IServiceScope scope = serviceProvider.CreateScope();
            serviceProvider = scope.ServiceProvider;
            AppDbContext context = serviceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            logger.Information("EFCore migrations completed");
        }
        catch (Exception ex)
        {
            logger.Error(ex, "An error occured during migration");
        }
        return serviceProvider;
    }
}
