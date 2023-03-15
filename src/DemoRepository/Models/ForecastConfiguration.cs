using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoRepository.Models;

public class ForecastConfiguration : IEntityTypeConfiguration<Forecast>
{
  public void Configure(EntityTypeBuilder<Forecast> builder)
  {
    builder
      .HasOne<City>(f => f.City)
      .WithMany(c => c.Forecasts);
  }
}
