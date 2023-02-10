using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Domain.Common;
using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPark.Persistence;

/*
    cd DigitalPark.Persistence
    dotnet ef migrations add Initial -p ../DigitalPark.Persistence -s ../DigitalPark.Client
    dotnet ef database update -p ../DigitalPark.Persistence -s ../DigitalPark.Client
*/

public class DigitalParkDbContext : DbContext, IDigitalParkDbContext
{
    private readonly ICurrentUserService _currentUserService;
    
    public DigitalParkDbContext(DbContextOptions<DigitalParkDbContext> options) : base(options) { }
    
    public DigitalParkDbContext(DbContextOptions<DigitalParkDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<EventContent> EventContents { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema("digital-park");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DigitalParkDbContext).Assembly);
    }
}