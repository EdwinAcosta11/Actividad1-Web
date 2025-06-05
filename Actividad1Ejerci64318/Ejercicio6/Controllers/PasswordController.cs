using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        // Ruta: /api/password/generate?length=12&includeSymbols=true
        [HttpGet("generate")]
        public IActionResult Generate(int length = 12, bool includeSymbols = false)
        {
            if (length < 6 || length > 100)
                return BadRequest("La longitud debe estar entre 6 y 100 caracteres.");

            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string validChars = letters + digits;

            if (includeSymbols)
                validChars += symbols;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(validChars.Length);
                password.Append(validChars[index]);
            }

            return Ok(new
            {
                Length = length,
                IncludeSymbols = includeSymbols,
                Password = password.ToString()
            });
        }
    }
}

