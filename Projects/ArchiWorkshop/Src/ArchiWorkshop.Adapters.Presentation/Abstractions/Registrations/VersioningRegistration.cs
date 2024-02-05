using ArchiWorkshop.Applications.Abstractions.CQRS;
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text.Unicode;
using System.Text;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class VersioningRegistration
{
    private const string ApiVersionQueryString = "api-version";
    private const string ApiVersionHeader = "x-version";
    private const string ApiVersionMediaType = "ver";

    internal static IServiceCollection RegisterVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = ApiVersion.Default;
                //options.DefaultApiVersion = new ApiVersion(1.5);

                // 버전
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(ApiVersionQueryString),     // /api/StringList?api-version=1.0
                    new HeaderApiVersionReader(ApiVersionHeader),               // /api/StringList      x-version    1.0
                    new MediaTypeApiVersionReader(ApiVersionMediaType),         // /api/StringList      application/json;ver=2.0
                    new UrlSegmentApiVersionReader());                          // /api/v3/StringList

                // "api-version" required 제거
                options.AssumeDefaultVersionWhenUnspecified = true;

                // Response headers
                //    api-deprecated-versions: 1.0                      <- ReportApiVersions = true;
                //    api-supported-versions: 2.0
                //
                //    content-type: application/json; charset=utf-8
                //    date: Fri,02 Feb 2024 14:57:46 GMT
                //    server: Kestrel
                //    transfer-encoding: chunked
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>      // IApiVersionDescriptionProvider 구현체 DI 등록
            {
                // https://github.com/dotnet/aspnet-api-versioning/wiki/Version-Format#custom-api-version-format-strings
                // "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // 버전 URL 포함
                // [ApiVersion(2.0)]
                // [Route("api/v{version:apiVersion}/[controller]")]
                // public class UsersController : ControllerBase
                //
                // api/v2/users
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }
}