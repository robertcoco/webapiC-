using Microsoft.AspNetCore.Mvc;

namespace Api_Rest_con_C_.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        // Checking if the list is empty or null.
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // you can easily modify your routes by using the Route() function and passing it the route you wanna
    // add to the root route.
    // you can add multiple routes to a single get
    //[Route("Get/weatherForecast")]
    //[Route("Get/weatherForecast2")]
    // We cann too add a route with the dynamic word action, that gets name of the method as route.
    //[Route("[action]")]

    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Se ha ejecutado correctamente");
        return ListWeatherForecast;
    }

    // Adding post method with static information
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    // Adding delete method with static information
    [HttpDelete ("{Index}")]
    public IActionResult Delete(int Index)
    {
        if (ListWeatherForecast.Count <= Index)
        {
            return BadRequest("The index is out of bound :(");
        }

        ListWeatherForecast.RemoveAt(Index);
        return Ok("Forecast was removed successfully :)");
    }
}
