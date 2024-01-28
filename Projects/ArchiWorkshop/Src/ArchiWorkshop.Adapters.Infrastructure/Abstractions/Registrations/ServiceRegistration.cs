using ArchiWorkshop.Adapters.Infrastructure.Validators;
using ArchiWorkshop.Applications.Abstractions.CQRS;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Validator
        services.AddScoped<IValidator, Validator>();

        return services;
    }
}
