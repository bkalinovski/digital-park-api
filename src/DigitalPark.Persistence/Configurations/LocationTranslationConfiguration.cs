using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class LocationTranslationConfiguration : IEntityTypeConfiguration<LocationTranslation>
{
    public void Configure(EntityTypeBuilder<LocationTranslation> builder)
    {
           builder.ToTable("LocationTranslations")
                  .HasKey(t => new { t.LocationId, t.LanguageCode });

        builder.Property(t => t.Title)
               .HasColumnType("nvarchar(50)")
               .HasMaxLength(50)
               .IsRequired();

        builder.HasOne(t => t.Location)
               .WithMany(t => t.Translations)
               .HasPrincipalKey(t => t.Id)
               .HasForeignKey(t => t.LocationId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Language)
               .WithMany(t => t.LocationTranslations)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
    }
}