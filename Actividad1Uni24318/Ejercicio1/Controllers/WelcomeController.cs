using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        // GET: api/<WelcomeController>
        [HttpGet]
        public IActionResult GetwlcomeMessage(String name)
        {
            return Ok(string.Format("Hola {0}, un placer conocerte", name));
        }

       
    }
}
