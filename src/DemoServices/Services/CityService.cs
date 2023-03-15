
using DemoDomain.Interfaces;
using DemoDomain.Messages;
using DemoDomain.Responses;
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

    public async Task<CityAddedResponse> AddCity(string name)
    {
      var city = new City() {
        Name = name
      };

      cities.Add(city);

      await context.SaveChangesAsync();

      await messageBus.Publish(new CityAdded() {
        City = name
      });

      return new CityAddedResponse {
        Id = city.Id,
        Name = city.Name
      };
    }

    public async Task<object[]?> ListCities()
    {
       return cities.ToList().ToArray();
    }
  }
}