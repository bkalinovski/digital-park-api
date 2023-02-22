using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class EventTranslationConfiguration : IEntityTypeConfiguration<EventTranslation>
{
    public void Configure(EntityTypeBuilder<EventTranslation> builder)
    {
           builder.ToTable("EventTranslations")
                  .HasKey(t => new { t.EventId, t.LanguageCode });

        builder.Property(t => t.Title)
               .HasColumnType("nvarchar(50)")
               .HasMaxLength(50)
               .IsRequired();
        
        builder.Property(t => t.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000)
               .IsRequired();
        
        builder.Property(t => t.Image)
               .HasColumnType("nvarchar(max)")
               .IsRequired();

        builder.HasOne(t => t.Event)
               .WithMany(t => t.Translations)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Language)
               .WithMany(t => t.EventTranslations)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
    }
}