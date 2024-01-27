var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services
    .RegisterAppOptions()
    .RegisterApplicationLayer()
    .RegisterAdapterLayerPersistence(builder.Environment)
    //.RegisterInfrastructureLayer()
    .RegisterAdapterLayerPresentation();

WebApplication webApplication = builder.Build();

webApplication
    .UseHttpsRedirection();
    //.UseApplicationLayer()
    //.UsePresentationLayer(builder.Environment)
    //.UsePersistenceLayer();

webApplication.MapControllers();

webApplication.Run();