
using DemoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository;

public class DemoRepositoryContext : DbContext 
{
  public DemoRepositoryContext(DbContextOptions<DemoRepositoryContext> options) : base(options)
  {
  }

  public DbSet<City> Cities { get; set; }
  public DbSet<Forecast> Forecasts { get; set; }
}