using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        // Suma: /api/calculator/add?a=3&b=5
        [HttpGet("add")]
        public IActionResult Add(double a, double b)
        {
            return Ok(a + b);
        }

        // Resta: /api/calculator/subtract?a=8&b=2
        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b)
        {
            return Ok(a - b);
        }

        // Multiplicación: /api/calculator/multiply?a=4&b=6
        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b)
        {
            return Ok(a * b);
        }

        // División: /api/calculator/divide?a=10&b=2
        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            if (b == 0)
                return BadRequest("No se puede dividir por cero.");
            return Ok(a / b);
        }
    }
}
