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

        builder.Property(t => t.TitleRo)
               .HasColumnType("nvarchar(50)")
               .HasMaxLength(50)
               .IsRequired();
        
        builder.Property(t => t.TitleEng)
               .HasColumnType("nvarchar(50)")
               .HasMaxLength(50)
               .IsRequired();
        
        builder.Property(t => t.DescriptionRo)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000)
               .IsRequired();
        
        builder.Property(t => t.DescriptionEng)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000)
               .IsRequired();
        
        builder.Property(t => t.ImageRo)
               .HasColumnType("nvarchar(max)")
               .IsRequired();
        
        builder.Property(t => t.ImageEng)
               .HasColumnType("nvarchar(max)")
               .IsRequired();

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
    }
}