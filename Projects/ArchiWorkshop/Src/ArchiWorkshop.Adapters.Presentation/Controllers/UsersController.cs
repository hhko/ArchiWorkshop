using ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;
using ArchiWorkshop.Applications.Features.Users.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchiWorkshop.Adapters.Presentation.Controllers;

//[ApiVersion(2.0)]
//[Route("api/v{version:apiVersion}/[controller]")]
public class UsersController : ApiController
{
    public UsersController(ISender sender)
        : base(sender)
    {

    }

    [HttpGet("{username}")]
    //[ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
    //[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    //public IActionResult GetUserByUsername(string userName)
    public async Task<IActionResult> GetUserByUserName([FromRoute] string userName, CancellationToken cancellationToken)
    {
        var query = new GetUserByUserNameQuery(userName);
        var result = await Sender.Send(query, default);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return Ok(result.Value);
    }
}
