using DemoDomain.Interfaces;
using DemoServices.Configuration;
using DemoServices.MessageConsumers;
using DemoServices.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoServices.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration config) {
        services.AddMassTransit(x =>
            {
                x.AddConsumer<CityAddedConsumer>();
                x.AddConsumer<ForecastAddedConsumer>();
                
                // No need to specify host since we're using a local rabbitmq instance
                // It is smart enough to use default values.
                x.UsingRabbitMq((context,cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IForecastService, ForecastService>();
    }
}
