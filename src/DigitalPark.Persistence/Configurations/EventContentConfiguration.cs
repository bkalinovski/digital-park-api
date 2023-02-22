using DigitalPark.Domain.Entities;
using DigitalPark.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class EventContentConfiguration : IEntityTypeConfiguration<EventContent>
{
    public void Configure(EntityTypeBuilder<EventContent> builder)
    {
        builder.ToTable("EventContents")
               .HasKey(t => t.Id);
              
        builder.Property(t => t.Id)
               .ValueGeneratedOnAdd();

        builder.Property(t => t.OrderNr)
               .HasColumnType("int")
               .IsRequired();

        builder.HasIndex(t => new { t.EventId, t.OrderNr })
               .IsUnique();

        builder.Property(t => t.Type)
               .HasColumnType("nvarchar(10)")
               .HasMaxLength(10)
               .HasConversion(type => type.ToString(), s => (ContentType)Enum.Parse(typeof(ContentType), s))
               .IsRequired();

        builder.HasOne(t => t.Event)
               .WithMany(t => t.Contents)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(t => t.Translations)
               .WithOne(t => t.EventContent)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventContentId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}