using ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;
using ArchiWorkshop.Applications.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchiWorkshop.Adapters.Presentation.Controllers;

//public class UsersController(ISender sender) : ApiController(sender)
public class UsersController : ApiController
{
    public UsersController(ISender sender)
        : base(sender)
    {
        
    }

    [HttpGet("{userName}")]
    //[ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
    //[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    //public IActionResult GetUserByUsername(string userName)
    public async Task<IActionResult> GetUserByUsername([FromRoute] string userName, CancellationToken cancellationToken)
    {
        var query = new GetUserByUsernameQuery(userName);
        var result = await Sender.Send(query, default);
        //var result = Sender.Send(query, default).Result;

        //if (result.IsFailure)
        //{
        //    return HandleFailure(result);
        //}

        return Ok(result.Value);
    }
}
