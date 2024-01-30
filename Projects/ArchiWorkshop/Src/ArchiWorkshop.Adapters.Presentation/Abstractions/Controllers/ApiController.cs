using ArchiWorkshop.Domains.Abstractions.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ArchiWorkshop.Applications.Abstractions.Utilities.ProblemDetailsUtilities;
using static ArchiWorkshop.Applications.Abstractions.Constants.Constants.ProblemDetails;
using IResult = ArchiWorkshop.Domains.Abstractions.Results.IResult;

namespace ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    public ApiController(ISender sender)
    {
        Sender = sender;
    }

    protected IActionResult HandleFailure(IResult result)
    {
        return result switch
        {
            // 성고일 때
            { IsSuccess: true } => throw new InvalidOperationException("Result was successful"),

            // 유효성 실패일 때
            IValidationResult validationResult => BadRequest
            (
                CreateProblemDetails(
                    ValidationError,
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.ValidationErrors
                )
            ),

            // 그 외 모든 실패
            _ => BadRequest(
                CreateProblemDetails(
                    InvalidRequest,
                    StatusCodes.Status400BadRequest,
                    result.Error
                )
            )
        };
    }
}

