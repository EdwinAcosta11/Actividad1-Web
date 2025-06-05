using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        // Ruta: /api/units/convert?from=km&to=miles&value=10
        // Ruta: /api/units/convert?from=lbs&to=kg&value=5
        [HttpGet("convert")]
        public IActionResult Convert(string from, string to, double value)
        {
            from = from.ToLower();
            to = to.ToLower();

            double result;

            // Conversión de distancia
            if (from == "km" && to == "miles")
            {
                result = value * 0.621371;
            }
            else if (from == "miles" && to == "km")
            {
                result = value / 0.621371;
            }
            // Conversión de peso
            else if (from == "lbs" && to == "kg")
            {
                result = value * 0.453592;
            }
            else if (from == "kg" && to == "lbs")
            {
                result = value / 0.453592;
            }
            else
            {
                return BadRequest("Conversión no soportada. Usa: km <-> miles, lbs <-> kg.");
            }

            return Ok(new
            {
                From = from,
                To = to,
                OriginalValue = value,
                ConvertedValue = Math.Round(result, 4)
            });
        }
    }
}

