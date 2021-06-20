using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace projectcApi.Controllers
{
    // Declare api controller to give it the appropriate attributes
    [ApiController]
    // sets the api route structure e.g. "/weatherforecast", but better to control
    // route on your own by adding it here "api/v1/weatherforecast"
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Property that houses what has been injected into the controller
        // Houses the logger in this case
        private readonly ILogger<WeatherForecastController> _logger;

        // Adding the 'logger' param here is the injection of the logger into the controller
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            // Setting the property
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
    }
}
