using Microsoft.AspNetCore.Mvc;

namespace SD2411.KPI2019.Module.Books.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Produces("application/json")]
    public class BooksApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Returning from Books");
        }
    }
}
