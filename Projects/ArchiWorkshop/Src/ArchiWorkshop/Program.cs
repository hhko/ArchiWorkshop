using Serilog;
using static ArchiWorkshop.Abstractions.Utilities.LoggerUtilities;

Log.Logger = CreateSerilogLogger();

try
{
    Log.Information("Staring the host");

    var builder = WebApplication.CreateBuilder(new WebApplicationOptions
    {
        Args = args,
        ContentRootPath = Directory.GetCurrentDirectory()
    });

    builder.ConfigureSerilog();

    builder.Services.RegisterAppOptions()
                    .RegisterApplicationLayer()
                    .RegisterAdapterLayerPersistence(builder.Environment)
                    .RegisterAdapterLayerInfrastructure()
                    .RegisterAdapterLayerPresentation();

    WebApplication app = builder.Build();

    app.UseHttpsRedirection()
       .UseAdapterLayerPresentation();
    //.UsePresentationLayer(builder.Environment)
    //.UsePersistenceLayer();

    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.Information("Ending the host");
    Log.CloseAndFlush();
}

return 0;
