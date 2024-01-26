using ArchiWorkshop.Applications.Abstractions.CQRS;
using ArchiWorkshop.Domains.Abstractions.Results;

namespace ArchiWorkshop.Applications.Abstractions.Utilities;

internal static class ResultUtilities
{
    public static IResult<TResponse> ToResult<TResponse>(this TResponse response)
        where TResponse : class, IResponse
    {
        return Result.Create(response);
    }

    //public static IResult<TResponse> ToResult<TResponse>(this ValidationResult<TResponse> response)
    //    where TResponse : class, IResponse
    //{
    //    return response;
    //}
}
