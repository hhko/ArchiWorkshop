using ArchiWorkshop.Domains.Abstractions.BaseTypes;

namespace ArchiWorkshop.Domains.Abstractions.Results;

public sealed partial class Error
{
    public static Error NotFound<TEntity>(string uniqueValue)
        where TEntity : class, IEntity
    {
        return New(
            $"{typeof(TEntity).Name}.{nameof(NotFound)}", 
            $"{typeof(TEntity).Name} for '{uniqueValue}' was not found.");
    }

    public static Error Exception(string exceptionMessage)
    {
        return New($"{nameof(Exception)}", exceptionMessage);
    }
}
