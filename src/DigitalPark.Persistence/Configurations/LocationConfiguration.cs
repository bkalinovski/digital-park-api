using DigitalPark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalPark.Persistence.Configurations;

internal class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations")
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
        
        builder.Property(t => t.CreatedAt)
               .HasColumnType("datetime2")
               .HasDefaultValueSql("getdate()")
               .IsRequired();

        builder.Property(t => t.IsActive)
               .HasColumnType("bit")
               .HasDefaultValue(true)
               .IsRequired();
    }
}