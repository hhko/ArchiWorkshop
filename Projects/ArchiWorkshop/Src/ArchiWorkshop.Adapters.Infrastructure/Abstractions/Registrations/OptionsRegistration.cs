//namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Registrations;
using ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        //services.ConfigureOptions<CacheOptionsSetup>();
        //services.ConfigureOptions<AuthenticationOptionsSetup>();
        //services.ConfigureOptions<BearerAuthenticationOptionsSetup>();
        //services.ConfigureOptions<HealthCheckOptionsSetup>();

        //services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();
        //services.AddSingleton<IValidateOptions<AuthenticationOptions>, AuthenticationOptionsValidator>();
        //services.AddSingleton<IValidateOptions<HealthOptions>, HealthOptionsValidator>();
        //services.AddSingleton<IValidateOptions<CacheOptions>, CacheOptionsValidator>();

        return services;
    }
}

