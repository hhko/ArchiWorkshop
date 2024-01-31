using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal static class FluentValidationRegistration
{
    internal static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            ArchiWorkshop.Applications.AssemblyReference.Assembly, 
            includeInternalTypes: true);

        return services;
    }
}
