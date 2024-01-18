using FluentValidation;

// DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
//namespace ArchiWorkshop.Applications.Abstractions.Registrations;
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
