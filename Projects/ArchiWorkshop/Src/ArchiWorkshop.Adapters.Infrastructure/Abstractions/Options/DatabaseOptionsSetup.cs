using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

internal sealed class DatabaseOptionsSetup(IConfiguration configuration,
                                           IWebHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
{
    public void Configure(DatabaseOptions options)
    {

    }
}