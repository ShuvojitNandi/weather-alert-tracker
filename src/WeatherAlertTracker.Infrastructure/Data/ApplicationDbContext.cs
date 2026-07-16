using Microsoft.EntityFrameworkCore;
using WeatherAlertTracker.Domain.Entities;

namespace WeatherAlertTracker.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {

  }

  public DbSet<City> Cities => Set<City>();

  public DbSet<Alert> Alerts => Set<Alert> ();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }
}