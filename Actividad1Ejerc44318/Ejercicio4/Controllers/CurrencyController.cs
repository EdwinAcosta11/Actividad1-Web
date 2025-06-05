using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        // Tabla simple de tasas de cambio (simulada)
        private readonly Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            { "USD", 1.0 },      // Dólar base
            { "EUR", 0.92 },     // 1 USD = 0.92 EUR
            { "DOP", 59.00 }     // 1 USD = 59.00 Pesos Dominicanos
        };

        // Ruta: /api/currency/convert?amount=100&from=USD&to=EUR
        [HttpGet("convert")]
        public IActionResult Convert(double amount, string from, string to)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (!exchangeRates.ContainsKey(from) || !exchangeRates.ContainsKey(to))
            {
                return BadRequest("Moneda no soportada. Usa USD, EUR o DOP.");
            }

            // Primero convierte a dólares (USD)
            double amountInUSD = amount / exchangeRates[from];

            // Luego convierte a la moneda destino
            double convertedAmount = amountInUSD * exchangeRates[to];

            return Ok(new
            {
                OriginalAmount = amount,
                From = from,
                To = to,
                ConvertedAmount = Math.Round(convertedAmount, 2)
            });
        }
    }
}
