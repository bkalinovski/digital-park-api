using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events")
               .HasKey(t => t.Id);
              
        builder.Property(t => t.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(t => t.Location)
               .WithMany(t => t.Events)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.LocationId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Contents)
               .WithOne(t => t.Event)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(t => t.Translations)
               .WithOne(t => t.Event)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}