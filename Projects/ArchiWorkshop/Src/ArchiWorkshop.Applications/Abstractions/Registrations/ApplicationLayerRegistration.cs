using Microsoft.AspNetCore.Builder;

// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Applications.Abstractions.Registrations;
namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationLayerRegistration
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services
            .RegisterValidation()
            .RegisterMediator();
            //.RegisterMiddlewares();

        return services;
    }

    // Microsoft.AspNetCore.Http.Abstractions
    //  - IApplicationBuilder
    public static IApplicationBuilder UseApplicationLayer(this IApplicationBuilder app)
    {
        //app.UseMiddlewares();

        return app;
    }
}
