using ArchiWorkshop.Applications.Abstractions.Pipelines;

namespace Microsoft.Extensions.DependencyInjection;

internal static class MediatRRegistration
{
    internal static IServiceCollection RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(ArchiWorkshop.Applications.AssemblyReference.Assembly);

            // Pipeline 호출 순서는 중요합니다.
            configuration.AddOpenBehavior(typeof(LoggingPipeline<,>));
            configuration.AddOpenBehavior(typeof(FluentValidationPipeline<,>));
        });

        return services;
    }
}
