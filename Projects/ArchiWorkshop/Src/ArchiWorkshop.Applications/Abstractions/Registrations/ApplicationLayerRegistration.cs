﻿namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationLayerRegistration
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services
            .RegisterFluentValidation()
            .RegisterMediatR();

        return services;
    }
}
