using ArchiWorkshop.Adapters.Presentation.OpenApi;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection;

public static class OpenApiRegistration
{
    private const string SwaggerDarkThameStyleFileName = "SwaggerDark.css";
    private const string WwwRootDirectoryName = "OpenApi";
    private const string ArchiWorkshopPresentation = $"{nameof(ArchiWorkshop)}.{nameof(ArchiWorkshop.Adapters.Presentation)}";

    internal static IServiceCollection RegisterOpenApi(this IServiceCollection services)
    {
        // services.ConfigureOptions<DatabaseOptionsSetup>();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, OpenApiOptionsSetup>();

        services.AddSwaggerGen(options =>
        {
            //options.OperationFilter<OpenApiDefaultValues>();
            //options.ExampleFilters();
            //options.IncludeXmlDocumentation(Shopway.Presentation.AssemblyReference.Assembly);
            //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            //options.OperationFilter<SecurityRequirementsOperationFilter>();
            //options.AddJwtAuthorization();
            //options.AddApiKeyAuthorization();
        });

        //services.AddSwaggerExamplesFromAssemblies(ArchiWorkshop.Adapters.Presentation.AssemblyReference.Assembly);

        return services;
    }

    public static IApplicationBuilder ConfigureOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            //options.InjectStylesheet("/swaggerstyles/SwaggerDark.css");
            options.InjectStylesheet("/SwaggerDark.css");
        });

        return app;
    }

    /*
    internal static IApplicationBuilder ConfigureOpenApi(this IApplicationBuilder app, bool isDevelopment)
    {
        if (isDevelopment)
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            UseStaticFiles(app);

            app.UseSwaggerUI(options =>
            {
                foreach (var groupName in provider.ApiVersionDescriptions.Select(x => x.GroupName))
                {
                    options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
                }

                options.InjectStylesheet($"/{SwaggerDarkThameStyleFileName}");
            });
        }

        return app;
    }

    private static void UseStaticFiles(IApplicationBuilder app)
    {
        var wwwRoot = Path.Combine($"{Directory.GetParent(Directory.GetCurrentDirectory())}", ShopwayPresentation, WwwRootDirectoryName);

        try
        {
            app
                .UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(wwwRoot)
                });
        }
        catch
        {
            app
                .UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
                });
        }
    }
    */
}
