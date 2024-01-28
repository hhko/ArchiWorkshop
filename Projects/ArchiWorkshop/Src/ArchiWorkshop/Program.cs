
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

    builder.Services
        .RegisterAppOptions()
        .RegisterApplicationLayer()
        .RegisterAdapterLayerPersistence(builder.Environment)
        .RegisterAdapterLayerInfrastructure()
        .RegisterAdapterLayerPresentation();

    WebApplication webApplication = builder.Build();

    webApplication
        .UseHttpsRedirection();
    //.UseApplicationLayer()
    //.UsePresentationLayer(builder.Environment)
    //.UsePersistenceLayer();

    webApplication.MapControllers();

    webApplication.Run();
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
