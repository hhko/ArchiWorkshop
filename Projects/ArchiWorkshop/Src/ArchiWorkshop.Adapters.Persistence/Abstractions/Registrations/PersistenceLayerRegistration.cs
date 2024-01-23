// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Applications.Abstractions.Registrations;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class PersistenceLayerRegistration
{
    public static IServiceCollection RegisterAdapterLayerPersistence(this IServiceCollection services, IHostEnvironment environment)
    {
        services.RegisterDatabaseContext(environment.IsDevelopment());

        return services;
    }
}
