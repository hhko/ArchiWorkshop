﻿using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArchiWorkshop.Adapters.Presentation.OpenApi;

// https://learn.microsoft.com/ko-kr/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio
// API 버전관리: https://jakeryu.github.io/api-%EB%B2%84%EC%A0%84%EA%B4%80%EB%A6%AC/
// SWAGGER를 이용한 API 문서관리: https://jakeryu.github.io/swagger-%EB%8B%A4%EC%A4%91%EB%AC%B8%EC%84%9C/
// https://www.linkedin.com/pulse/implementing-api-versioning-net-60-dimitar-iliev/
// https://medium.com/@dipendupaul/documenting-a-versioned-net-web-api-using-swagger-eec0fe7aa010

public sealed class OpenApiOptionsSetup
    : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    // AddApiExplorer 메서드에서 IApiVersionDescriptionProvider 구현체 DI 등록
    public OpenApiOptionsSetup(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    // IConfigureOptions 인터페이스 구현
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "Architecture Workshop for Domain-Driven Design",
            Version = description.ApiVersion.ToString(),
            Description = "Architecting is a series of trade-offs.",
            Contact = new OpenApiContact() { Name = "고형호", Email = "hyungho.ko@gmail.com" },
            TermsOfService = new Uri("https://github.com/hhko/ArchiWorkshop")
            //License = new OpenApiLicense() { Name = "License MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}
