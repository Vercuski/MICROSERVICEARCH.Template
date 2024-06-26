﻿using MassTransit;
using MICROSERVICEARCH.Application.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MICROSERVICEARCH.Application;

public static class DependencyInjection
{
    public static HostApplicationBuilder AddApplicationRegistration(this HostApplicationBuilder builder)
    {
        builder.AddOptionsRegistration()
               .AddMessagingRegistration();
        return builder;
    }

    private static HostApplicationBuilder AddOptionsRegistration(this HostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        builder.Services.Configure<ConnectionStringOptions>(GetSection<ConnectionStringOptions>(configuration));
        builder.Services.Configure<MessagingOptions>(GetSection<MessagingOptions>(configuration));
        builder.Services.Configure<LogOptions>(GetSection<LogOptions>(configuration));
        return builder;
    }


    private static IConfigurationSection GetSection<T>(ConfigurationManager configuration)
        where T : BaseOptionsConfig
    {
        var config = Activator.CreateInstance(typeof(T))!;
        var section = ((BaseOptionsConfig)config).Section;
        return configuration.GetSection(section);
    }

    private static HostApplicationBuilder AddMessagingRegistration(this HostApplicationBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        var rabbitMQOptions = serviceProvider.GetService<IOptions<MessagingOptions>>()!.Value;

        builder.Services.AddMassTransit(setup =>
        {
            var prefix = $"MICROSERVICEARCH.";
            setup.SetEndpointNameFormatter(new DefaultEndpointNameFormatter(prefix: prefix, includeNamespace: false));
            setup.UsingRabbitMq((context, config) =>
            {
                config.Host(rabbitMQOptions.Host, rabbitMQOptions.VirtualHost, h =>
                {
                    h.Username(rabbitMQOptions.Username);
                    h.Password(rabbitMQOptions.Password);
                });

                config.ConfigureEndpoints(context);
            });
        });
        return builder;
    }
}
