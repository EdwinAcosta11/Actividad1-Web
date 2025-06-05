using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalindromeController : ControllerBase
    {
        // Ruta: /api/palindrome/check?text=radar
        [HttpGet("check")]
        public IActionResult Check(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("El texto no puede estar vacío.");

            // Limpiar el texto: quitar espacios, mayúsculas y signos
            string cleanedText = Regex.Replace(text.ToLower(), @"[^a-z0-9]", "");

            // Verificar si es palíndromo
            char[] reversedArray = cleanedText.Reverse().ToArray();
            string reversed = new string(reversedArray);

            bool isPalindrome = cleanedText == reversed;

            return Ok(new
            {
                OriginalText = text,
                IsPalindrome = isPalindrome
            });
        }
    }
}

