using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static ArchiWorkshop.Adapters.Presentation.Abstractions.Utilities.ProblemDetailsUtilities;
using static ArchiWorkshop.Applications.Abstractions.Constants.Constants.ProblemDetails;
using ArchiWorkshop.Domains.Abstractions.Results;
using Microsoft.AspNetCore.Mvc;
using ArchiWorkshop.Applications.Abstractions.Exceptions;

namespace ArchiWorkshop.Adapters.Presentation.Abstractions.Middlewares;

public sealed class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    private const string ProblemDetailsContentType = "application/problem+json";
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                NotFoundException => 404,
                BadRequestException => 400,
                ForbidException => 403,
                _ => 500
            };

            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = CreateProblemDetails(title: ExceptionOccurred,
                                                  status: context.Response.StatusCode,
                                                  error: Error.Exception(exception.Message),
                                                  context: context);

        _logger.LogUnexpectedException(context.Request.Method,
                                       context.Request.Path,
                                       exception.GetType().Name,
                                       exception.Source,
                                       exception.Message,
                                       exception.StackTrace);


        await context.Response.WriteAsJsonAsync(problemDetails,
                                                typeof(ProblemDetails),
                                                options: null,
                                                contentType: ProblemDetailsContentType);
    }
}

public static partial class LoggerMessageDefinitionsUtilities
{
    [LoggerMessage(
        EventId = 10,
        EventName = $"{nameof(ErrorHandlingMiddleware)}",
        Level = LogLevel.Error,
        Message = "Request [{Method}] at {Path} thrown an exception '{Name}' from source '{Source}'. \n Exception message: '{Message}'. \n StackTrace: '{StackTrace}'",
        SkipEnabledCheck = true)]
    public static partial void LogUnexpectedException(this ILogger logger,
                                                      string method,
                                                      PathString path,
                                                      string name,
                                                      string? source,
                                                      string message,
                                                      string? stackTrace);
}