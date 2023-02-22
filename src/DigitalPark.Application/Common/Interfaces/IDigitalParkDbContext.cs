using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPark.Application.Common.Interfaces;

public interface IDigitalParkDbContext
{
    DbSet<Location> Locations { get; set; }
    
    DbSet<LocationTranslation> LocationsTranslations { get; set; }
    
    DbSet<Event> Events { get; set; }
    
    DbSet<EventTranslation> EventsTranslations { get; set; }

    DbSet<EventContent> EventContents { get; set; }
    
    DbSet<EventContentTransation> EventContentTransations { get; set; }

    DbSet<Language> Languages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}