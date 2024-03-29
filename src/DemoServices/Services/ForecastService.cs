
using DemoDomain.Interfaces;
using DemoDomain.Messages;
using DemoDomain.Responses;
using DemoRepository;
using DemoRepository.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DemoServices.Services
{
  public class ForecastService : IForecastService
  {
    private IBus messageBus;
    private DbSet<Forecast> forecasts;
    private DbSet<City> cities;
    private DemoRepositoryContext context;

    public ForecastService(
      IBus messageBus, 
      DemoRepositoryContext context)
    {
        this.messageBus = messageBus;
        this.context = context;
        this.cities = context.City;
        this.forecasts = context.Forecast;
    }
    
    public async Task<ForecastAddedResponse> AddForecast(int cityId, int temperatureF)
    {
        var city = cities.FirstOrDefault(c => c.Id == cityId);

        if (city == null) throw new Exception("City not found.");

        var forecast = new Forecast() {
            City = city,
            TemperatureF = temperatureF
        };
      
        forecasts.Add(forecast);

        await context.SaveChangesAsync();

        await messageBus.Publish(new ForecastAdded() {
            CityId = cityId,
            CityName = city.Name,
            TemperatureF = temperatureF
        });

        return new ForecastAddedResponse {
          Id = forecast.Id,
          CityId = city.Id,
          TemperatureF = forecast.TemperatureF
        };
    }

    public async Task<object[]?> ListForecasts()
    {
      return forecasts.Select(f => new { id = f.Id, cityId = f.City.Id, temperatureF = f.TemperatureF }).ToList().ToArray();
    }
  }
}