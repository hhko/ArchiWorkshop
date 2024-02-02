using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchiWorkshop.Adapters.Presentation.Controllers;

//[ApiController]
////[Route("api/[controller]")]
//[ApiVersion(1.0, Deprecated = true)]
//[ApiVersion(2.0)]
//[Route("api/v{version:apiVersion}/[controller]")]
public class GreetingController : ControllerBase
{
    public GreetingController(ISender sender)
    {
        
    }

    [HttpGet("{name}")]
    public IActionResult Execute(string name)
    {
        return Ok(new
        {
            Hello = $"World, {name}"
        });
    }
}

//public class MyRequest
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public int Age { get; set; }
//}

//public class MyResponse
//{
//    public string FullName { get; set; }
//    public bool IsOver18 { get; set; }
//}

//await SendAsync(new ()
//{
//    FullName = req.FirstName + " " + req.LastName,
//    IsOver18 = req.Age > 18
//});

//{
//    "FirstName": "Marlon",
//    "LastName": "Brando",
//    "Age": 40
//}

//{
//    "FullName": "Marlon Brando",
//    "IsOver18": true
//}