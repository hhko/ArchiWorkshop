using ArchiWorkshop.Adapters.Presentation.Abstractions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class MiddlewaresRegistration
{
    internal static IServiceCollection RegisterMiddlewares(this IServiceCollection services)
    {
        // Middleware 호출 순서는 중요합니다.
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<RequestTimeMiddleware>();

        return services;
    }

    internal static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        // Middleware 호출 순서는 중요합니다.
        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<RequestTimeMiddleware>();

        return app;
    }
}
