var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

builder.Services
    .RegisterAppOptions()
    .RegisterApplicationLayer();
    // .RegisterPersistenceLayer(builder.Environment)
    // .RegisterInfrastructureLayer()
    //.RegisterAdapterLayerWebApi();