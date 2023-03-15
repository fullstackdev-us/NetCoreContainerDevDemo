
using DemoRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoRepository;

public class DemoRepositoryContext : DbContext 
{
  public DemoRepositoryContext(DbContextOptions<DemoRepositoryContext> options) : base(options)
  {
  }

  // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //       {
  //           var configuration = new ConfigurationBuilder()
  //               .SetBasePath(Directory.GetCurrentDirectory())
  //               .AddJsonFile("appsettings.json")
  //               .Build();

  //           var connectionString = configuration.GetConnectionString("DefaultConnection");
  //           optionsBuilder.UseSqlServer(connectionString);
  //       }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoRepositoryContext).Assembly);
  }

  public DbSet<City> City { get; set; }
  public DbSet<Forecast> Forecast { get; set; }
}