var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services
    .RegisterAppOptions()
    .RegisterApplicationLayer()
    .RegisterAdapterLayerPersistence(builder.Environment);
    //.RegisterInfrastructureLayer()
    //.RegisterPresentationLayer();

WebApplication webApplication = builder.Build();

webApplication.Run();