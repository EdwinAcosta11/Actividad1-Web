using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomController : ControllerBase
    {
        // Ruta: /api/random?min=1&max=100
        [HttpGet]
        public IActionResult GetRandomNumber(int min = 1, int max = 100)
        {
            if (min >= max)
                return BadRequest("El valor mínimo debe ser menor que el valor máximo.");

            Random rnd = new Random();
            int number = rnd.Next(min, max + 1); // +1 porque es exclusivo

            return Ok(new
            {
                Min = min,
                Max = max,
                RandomNumber = number
            });
        }
    }
}

