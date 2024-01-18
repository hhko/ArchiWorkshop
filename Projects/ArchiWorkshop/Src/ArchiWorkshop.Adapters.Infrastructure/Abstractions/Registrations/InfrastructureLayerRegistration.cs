//namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Registrations;
namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAppOptions(this IServiceCollection services)
    {
        services.RegisterOptions();

        return services;
    }
}
