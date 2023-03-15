using DemoDomain.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace DemoServices.MessageConsumers;

public class CityAddedConsumer : IConsumer<CityAdded>
{
  private readonly ILogger<CityAddedConsumer> logger;

  public CityAddedConsumer(ILogger<CityAddedConsumer> logger)
  {
    this.logger = logger;
  }

  public Task Consume(ConsumeContext<CityAdded> context)
  {
    logger.LogInformation($"City Added: {context.Message.City}");

    return Task.CompletedTask;
  }
}
