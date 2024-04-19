using MICROSERVICEARCH.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MICROSERVICEARCH.Application;

public static class DependencyInjection
{
    public static HostApplicationBuilder AddApplicationRegistration(this HostApplicationBuilder builder)
    {
        builder.Services.AddOptionsRegistration(builder.Configuration);
        return builder;
    }

    public static IServiceCollection AddOptionsRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringOptions>(GetSection<ConnectionStringOptions>(configuration));
        services.Configure<MessagingOptions>(GetSection<MessagingOptions>(configuration));
        services.Configure<LogOptions>(GetSection<LogOptions>(configuration));
        return services;
    }


    public static IConfigurationSection GetSection<T>(IConfiguration configuration)
        where T : BaseOptions
    {
        var config = Activator.CreateInstance(typeof(T))!;
        var section = ((BaseOptions)config).Section;
        return configuration.GetSection(section);
    }
}
