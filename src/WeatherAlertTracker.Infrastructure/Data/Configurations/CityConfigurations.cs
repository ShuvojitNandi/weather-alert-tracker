using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Infrastructure.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
      
      builder.ToTable("Cities");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Name)
       .IsRequired()
       .HasMaxLength(100);

      builder.Property(c => c.Province)
       .IsRequired()
       .HasMaxLength(100);
      
      builder.Property(c => c.Country)
       .IsRequired()
       .HasMaxLength(100);

      builder.Property(c => c.Latitude)
       .IsRequired();

      builder.Property(c => c.Longitude)
       .IsRequired();

      builder.Property(c => c.CreatedAt)
       .IsRequired();

      builder.HasMany(c => c.Alerts)
       .WithOne(a => a.City)
       .HasForeignKey(a => a.CityId)
       .OnDelete(DeleteBehavior.Cascade);
    }
}