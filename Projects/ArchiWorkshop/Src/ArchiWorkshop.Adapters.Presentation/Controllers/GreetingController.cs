using ArchiWorkshop.Adapters.Presentation.Abstractions.Controllers;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArchiWorkshop.Adapters.Presentation.Controllers;

//[ApiController]
//[Route("[controller]")]
//[ApiVersion("0.1", Deprecated = true)]
[ApiVersion("1.5", Deprecated = true)]
public class WeatherForecastController : ApiController
{
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ISender sender, ILogger<WeatherForecastController> logger)
        : base(sender)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

//[ApiController]
////[Route("api/[controller]")]
//[ApiVersion(1.0, Deprecated = true)]
//[ApiVersion(2.0)]
//[Route("api/v{version:apiVersion}/[controller]")]
public class GreetingController : ApiController
{
    public GreetingController(ISender sender)
        : base(sender)
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

////public class MyRequest
////{
////    public string FirstName { get; set; }
////    public string LastName { get; set; }
////    public int Age { get; set; }
////}

////public class MyResponse
////{
////    public string FullName { get; set; }
////    public bool IsOver18 { get; set; }
////}

////await SendAsync(new ()
////{
////    FullName = req.FirstName + " " + req.LastName,
////    IsOver18 = req.Age > 18
////});

////{
////    "FirstName": "Marlon",
////    "LastName": "Brando",
////    "Age": 40
////}

////{
////    "FullName": "Marlon Brando",
////    "IsOver18": true
////}