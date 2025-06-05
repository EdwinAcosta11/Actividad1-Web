using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {
        // Convierte Celsius a Fahrenheit: /api/temperature/toFahrenheit?celsius=25
        [HttpGet("toFahrenheit")]
        public IActionResult ToFahrenheit(double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            return Ok(fahrenheit);
        }

        // Convierte Fahrenheit a Celsius: /api/temperature/toCelsius?fahrenheit=77
        [HttpGet("toCelsius")]
        public IActionResult ToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
            return Ok(celsius);
        }
    }
}
