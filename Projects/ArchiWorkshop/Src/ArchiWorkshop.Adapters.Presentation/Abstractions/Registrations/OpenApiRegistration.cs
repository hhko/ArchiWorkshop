using ArchiWorkshop.Adapters.Presentation.OpenApi;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection;

public static class OpenApiRegistration
{
    private const string SwaggerDarkThameStyleFileName = "SwaggerDark.css";
    private const string WwwRootDirectoryName = "OpenApi";
    private const string ArchiWorkshopPresentation = $"{nameof(ArchiWorkshop)}.{nameof(ArchiWorkshop.Adapters)}.{nameof(ArchiWorkshop.Adapters.Presentation)}";

    internal static IServiceCollection RegisterOpenApi(this IServiceCollection services)
    {
        // services.ConfigureOptions<DatabaseOptionsSetup>();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, OpenApiOptionsSetup>();

        services.AddSwaggerGen(options =>
        {
            // IOperationFilter
            //options.OperationFilter<OpenApiDefaultValues>();

            //// IExamplesProvider<T>
            //// ExamplesOperationFilter
            //options.ExampleFilters();

            //options.IncludeXmlDocumentation(Shopway.Presentation.AssemblyReference.Assembly);

            // IOperationFilter
            //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            //options.OperationFilter<SecurityRequirementsOperationFilter>();
            //options.AddJwtAuthorization();
            //options.AddApiKeyAuthorization();
        });

        //services.AddSwaggerExamplesFromAssemblies(ArchiWorkshop.Adapters.Presentation.AssemblyReference.Assembly);

        return services;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        
        // 정적 파일
        UseStaticFiles(app);

        var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
        app.UseSwaggerUI(options =>
        {
            // Select a definition: V1
            foreach (var groupName in provider.ApiVersionDescriptions.Select(x => x.GroupName))
            {
                options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
            }

            // Swagger Theme 정적 파일
            options.InjectStylesheet($"/{SwaggerDarkThameStyleFileName}");
        });

        return app;
    }

    private static void UseStaticFiles(IApplicationBuilder app)
    {
        // ... \ArchiWorkshop\Src\ArchiWorkshop             <- Directory.GetCurrentDirectory()
        // ... \ArchiWorkshop\Src                           <- Directory.GetParent(Directory.GetCurrentDirectory())
        //          \ArchiWorkshop.Adapters.Presentation    <- ArchiWorkshopPresentation
        //          \OpenApi                                <- WwwRootDirectoryName
        var wwwRootDir = Path.Combine($"{Directory.GetParent(Directory.GetCurrentDirectory())}",
                                      ArchiWorkshopPresentation, 
                                      WwwRootDirectoryName);

        try
        {
            app.UseStaticFiles(new StaticFileOptions() 
               {
                   FileProvider = new PhysicalFileProvider(wwwRootDir)
               });
        }
        catch
        {
            app.UseStaticFiles(new StaticFileOptions()
               {
                   FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
               });
        }
    }
}
