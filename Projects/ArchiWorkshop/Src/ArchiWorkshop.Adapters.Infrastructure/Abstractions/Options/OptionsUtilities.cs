using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ArchiWorkshop.Adapters.Infrastructure.Abstractions.Options;

public static class OptionsUtilities
{
    public static TOptions GetOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, new()
    {
        return services.BuildServiceProvider()
                       .GetRequiredService<IOptions<TOptions>>().Value;
    }
}