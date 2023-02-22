using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages")
               .HasKey(t => t.Code);
        
        builder.Property(t => t.Title)
               .HasColumnType("nvarchar(20)")
               .HasMaxLength(20)
               .IsRequired();

        builder.HasMany(t => t.EventTranslations)
               .WithOne(t => t.Language)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(t => t.LocationTranslations)
               .WithOne(t => t.Language)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(t => t.EventContentTransations)
               .WithOne(t => t.Language)
               .HasPrincipalKey(t => t.Code)
               .HasForeignKey(t => t.LanguageCode)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);
    }
}