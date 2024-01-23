using ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DatabaseContextRegistration
{
    internal static IServiceCollection RegisterDatabaseContext(this IServiceCollection services, bool isDevelopment)
    {
        var databaseOptions = services.GetOptions<DatabaseOptions>();
        return services;
    }
}
