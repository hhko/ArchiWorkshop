using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

internal sealed class DatabaseOptionsSetup(IConfiguration configuration,
                                           IWebHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
{
    // 생성자
    private readonly IConfiguration _configuration = configuration;
    private readonly IWebHostEnvironment _environment = environment;

    // Key 이름
    private const string _configurationSectionName = "DatabaseOptions";
    //private const string _productionConnection = "ProductionConnection";
    //private const string _stagingConnection = "StagingConnection";
    //private const string _developmentConnection = "DevelopmentConnection";

    public void Configure(DatabaseOptions options)
    {
        // | Env.         | ASPNETCORE_ENVIRONMENT Env.               | appsettings File              |
        // }--------------|-------------------------------------------|-------------------------------|
        // | Production   | "ASPNETCORE_ENVIRONMENT": ""              | appsettings.json              |
        // | Staging      | "ASPNETCORE_ENVIRONMENT": "Staging"       | appsettings.Staging.json      |
        // | Development  | "ASPNETCORE_ENVIRONMENT": "Development"   | appsettings.Development.json  |

        //if (_environment.IsProduction() is true)
        //{
        //    options.ConnectionString = _configuration.GetConnectionString(_productionConnection);
        //}
        //else if (_environment.IsStaging() is true)
        //{
        //    options.ConnectionString = _configuration.GetConnectionString(_stagingConnection);
        //}
        //else if (_environment.IsDevelopment() is true)
        //{
        //    options.ConnectionString = _configuration.GetConnectionString(_developmentConnection);
        //}

        // "ASPNETCORE_ENVIRONMENT": "..."
        //  - appsettings.json
        //  - appsettings.Staging.json
        //  - appsettings.Development.json
        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);
    }
}