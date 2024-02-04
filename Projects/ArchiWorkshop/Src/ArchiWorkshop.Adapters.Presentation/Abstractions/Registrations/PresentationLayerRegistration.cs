using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class PresentationLayerRegistration
{
    public static IServiceCollection RegisterAdapterLayerPresentation(this IServiceCollection services)
    {
        services.RegisterControllers()
                .RegisterMiddlewares()
                .RegisterOpenApi()
                .RegisterVersioning();

        //services.Scan(selector => selector
        //    .FromAssemblies(
        //        Shopway.Presentation.AssemblyReference.Assembly)
        //    .AddClasses(false)
        //    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //    .AsMatchingInterface()
        //    .WithScopedLifetime());

        return services;
    }

    //IHostEnvironment environment
    public static IApplicationBuilder UseAdapterLayerPresentation(this IApplicationBuilder app)
    {
        app.UseMiddlewares()
           .UseOpenApi();

        return app;
    }
}
