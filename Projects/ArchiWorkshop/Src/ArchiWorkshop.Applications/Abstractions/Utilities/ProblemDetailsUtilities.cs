using ArchiWorkshop.Domains.Abstractions.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ArchiWorkshop.Applications.Abstractions.Constants.Constants.ProblemDetails;

namespace ArchiWorkshop.Applications.Abstractions.Utilities;

public static class ProblemDetailsUtilities
{
    public static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null,
        HttpContext? context = null)
    {
        var problemDetails = new ProblemDetails()
        {
            Type = error.Code,
            Title = title,
            Detail = error.Message,         // 추가
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };

        // 추가
        if (context is not null)
        {
            problemDetails.Extensions.Add(RequestId, context.TraceIdentifier);
            problemDetails.Instance = context.Request.Path;
        }

        return problemDetails;
    }

    public static ProblemDetails CreateProblemDetails(
        string type,
        string title,
        int status,
        IList<string> errors)
    {
        var problemDetails = new ProblemDetails()
        {
            Type = type,
            Title = title,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };

        return problemDetails;
    }
}
