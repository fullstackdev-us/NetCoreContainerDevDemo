using DemoDomain.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace DemoServices.MessageConsumers;

public class ForecastAddedConsumer : IConsumer<ForecastAdded>
{
  private readonly ILogger<ForecastAddedConsumer> logger;

  public ForecastAddedConsumer(ILogger<ForecastAddedConsumer> logger)
  {
    this.logger = logger;
  }

  public Task Consume(ConsumeContext<ForecastAdded> context)
  {
    logger.LogInformation($"Forecast Added: City: {context.Message.CityName} Temperature (F): {context.Message.TemperatureF}");

    return Task.CompletedTask;
  }
}
