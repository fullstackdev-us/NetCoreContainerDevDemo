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
        var rabbitMqConfig = new RabbitMqConfig();
        config.GetSection(RabbitMqConfig.SectionName).Bind(rabbitMqConfig);

        services.AddMassTransit(x =>
            {
                x.AddConsumer<CityAddedConsumer>();
                x.AddConsumer<ForecastAddedConsumer>();
                
                x.UsingRabbitMq((context,cfg) =>
                {
                    cfg.Host(rabbitMqConfig.Host, rabbitMqConfig.VirtualHost, h => {
                        h.Username(rabbitMqConfig.Username);
                        h.Password(rabbitMqConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IForecastService, ForecastService>();
            
    }
}
