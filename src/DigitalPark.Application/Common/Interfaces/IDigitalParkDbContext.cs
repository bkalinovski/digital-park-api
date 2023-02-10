using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPark.Application.Common.Interfaces;

public interface IDigitalParkDbContext
{
    DbSet<Event> Events { get; set; }
    
    DbSet<Location> Locations { get; set; }
    
    DbSet<EventContent> EventContents { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}