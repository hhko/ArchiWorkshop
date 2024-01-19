//// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
////namespace ArchiWorkshop.Applications.Abstractions.Registrations;
//using ArchiWorkshop.Adapters.Persistence.Abstractions.Pipelines;

using ArchiWorkshop.Applications.Abstractions.Pipelines;

// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Adapters.Persistence.Abstractions.Registrations;
namespace Microsoft.Extensions.DependencyInjection;

public static class MediatorRegistration
{
    internal static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(ArchiWorkshop.Applications.AssemblyReference.Assembly);
            //configuration.AddOpenBehavior(typeof(LoggingPipeline<,>));
            configuration.AddOpenBehavior(typeof(FluentValidationPipeline<,>));
        });

        return services;
    }
}
