using Microsoft.AspNetCore.Mvc;
using SD2411.KPI2019.Module.BookLending.Model;
using SD2411.KPI2019.Module.BookLending.Services;
using System.Net;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.BookLending.Controllers
{
    [Route("api/booklending")]
    [ApiController]
    [Produces("application/json")]
    public class BookLendingApiController : Controller
    {
        private readonly IBookLendingService _bookLendingService;
        public BookLendingApiController(IBookLendingService bookLendingService)
        {
            this._bookLendingService = bookLendingService;
        }
        /// <summary>
        /// Get list of books with are borrowed by User
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("{userid}/books")]
        [ProducesResponseType(typeof(BooksBorrowedByUserResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            var result = await _bookLendingService.BooksBorrowedByUserAsync(userId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
