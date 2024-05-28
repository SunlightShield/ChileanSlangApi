using Microsoft.AspNetCore.Mvc;

namespace ChileanSlagApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController2 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController2(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast2")]
        public IEnumerable<WeatherForecast2> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast2
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
