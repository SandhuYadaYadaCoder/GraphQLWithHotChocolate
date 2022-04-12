using Common.Extensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Platform> Platforms { get; set; }
    public DbSet<PlatformCommand> Commands { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Platform>()
            .HasMany(x => x.Commands)
            .WithOne(x => x.Platform)
            .HasForeignKey(x => x.PlatformId);

        builder
            .Entity<PlatformCommand>()
            .HasOne(x => x.Platform)
            .WithMany(x => x.Commands)
            .HasForeignKey(x => x.PlatformId);

        builder
            .Entity<Platform>()
            .HasData(new List<Platform>()
            {
                new Platform
                {
                    Id = 1,
                    Name = ".Net 5",
                    LicenseKey = GuidExtension.FromString(".Net 5")                },
                new Platform
                {
                    Id = 2,
                    Name = "Docker",
                    LicenseKey = GuidExtension.FromString("Docker")
                },
                new Platform
                {
                    Id= 3,
                    Name = "Windows",
                    LicenseKey = GuidExtension.FromString("Windows")
                }
        });

        builder
            .Entity<PlatformCommand>()
            .HasData(new List<PlatformCommand>
            {
                new PlatformCommand
                {
                    Id = 1,
                    HowTo = "Build project",
                    CommandLine = "dotnet build",
                    PlatformId = 1
                },
                new PlatformCommand
                {
                    Id = 2,
                    HowTo = "Run project",
                    CommandLine = "dotnet run",
                    PlatformId = 1
                }
            });
    }
}
