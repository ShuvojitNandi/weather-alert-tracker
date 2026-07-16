using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Infrastructure.Data.Configurations;

public class AlertConfiguration : IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.WeatherType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Threshold)
            .IsRequired();

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.IsActive)
            .HasDefaultValue(true);

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.HasOne(a => a.City)
            .WithMany(c => c.Alerts)
            .HasForeignKey(a => a.CityId);
    }
}