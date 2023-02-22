using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class EventContentTranslationConfiguration : IEntityTypeConfiguration<EventContentTransation>
{
    public void Configure(EntityTypeBuilder<EventContentTransation> builder)
    {
           builder.ToTable("EventContentTranslations")
                  .HasKey(t => new { t.EventContentId, t.LanguageCode });

        builder.Property(t => t.Content)
               .HasColumnType("nvarchar(max)")
               .IsRequired();

        builder.HasOne(t => t.EventContent)
               .WithMany(t => t.Translations)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.EventContentId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Language)
               .WithMany(t => t.EventContentTransations)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
    }
}