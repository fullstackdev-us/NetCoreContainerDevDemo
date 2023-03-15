
using DemoDomain.Interfaces;
using DemoDomain.Messages;
using DemoRepository;
using DemoRepository.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DemoServices.Services
{
  public class CityService : ICityService
  {
    private IBus messageBus;
    private DbSet<City> cities;
    private DemoRepositoryContext context;

    public CityService(
      IBus messageBus,
      DemoRepositoryContext context
    )
    {
        this.messageBus = messageBus;
        this.context = context;
        this.cities = context.City;
    }

    public async Task AddCity(string name)
    {
      var city = new City() {
        Name = name
      };

      cities.Add(city);

      await context.SaveChangesAsync();

      await messageBus.Publish(new CityAdded() {
        City = name
      });
    }
  }
}