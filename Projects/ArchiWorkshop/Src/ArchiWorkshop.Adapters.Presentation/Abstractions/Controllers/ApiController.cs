using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
//public abstract class ApiController(ISender sender) : ControllerBase
//{
//    protected readonly ISender Sender = sender;
//}

public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    public ApiController(ISender sender)
    {
        Sender = sender;
    }
}

