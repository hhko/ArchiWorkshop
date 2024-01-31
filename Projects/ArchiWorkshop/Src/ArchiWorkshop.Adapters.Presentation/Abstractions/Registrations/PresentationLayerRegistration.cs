// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Applications.Abstractions.Registrations;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class PresentationLayerRegistration
{
    public static IServiceCollection RegisterAdapterLayerPresentation(this IServiceCollection services)
    {
        services
            .RegisterControllers()
            .RegisterMiddlewares();

        //services
        //    .RegisterControllers()
        //    .RegisterOpenApi()
        //    .RegisterVersioning()
        //    .RegisterAuthentication();

        //services.Scan(selector => selector
        //    .FromAssemblies(
        //        Shopway.Presentation.AssemblyReference.Assembly)
        //    .AddClasses(false)
        //    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //    .AsMatchingInterface()
        //    .WithScopedLifetime());

        return services;
    }

    public static IApplicationBuilder UseAdapterLayerPresentation(this IApplicationBuilder app)
    {
        app.UseMiddlewares();

        return app;
    }
}
