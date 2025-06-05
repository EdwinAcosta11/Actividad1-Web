using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgeController : ControllerBase
    {
        // Ruta: /api/age/calculate?birthDate=2000-05-10
        [HttpGet("calculate")]
        public IActionResult CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;

            if (birthDate > today)
                return BadRequest("La fecha de nacimiento no puede ser en el futuro.");

            int age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return Ok(new
            {
                BirthDate = birthDate.ToString("yyyy-MM-dd"),
                Age = age
            });
        }
    }
}
