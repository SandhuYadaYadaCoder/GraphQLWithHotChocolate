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
    public DbSet<PlatformCli> PlatformClis { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Platform>()
            .HasMany(x => x.PlatformClis)
            .WithOne(x => x.Platform)
            .HasForeignKey(x => x.PlatformId);

        builder
            .Entity<PlatformCli>()
            .HasOne(x => x.Platform)
            .WithMany(x => x.PlatformClis)
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
            .Entity<PlatformCli>()
            .HasData(new List<PlatformCli>
            {
                new PlatformCli
                {
                    Id = 1,
                    HowTo = "Build project",
                    CommandLine = "dotnet build",
                    PlatformId = 1
                },
                new PlatformCli
                {
                    Id = 2,
                    HowTo = "Run project",
                    CommandLine = "dotnet run",
                    PlatformId = 1
                }
            });
    }
}
