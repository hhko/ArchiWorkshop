﻿// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Applications.Abstractions.Registrations
namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAppOptions(this IServiceCollection services)
    {
        services.RegisterOptions();
        return services;
    }

    public static IServiceCollection RegisterAdapterLayerInfrastructure(this IServiceCollection services)
    {
        services.RegisterServices();
        return services;
    }
}
