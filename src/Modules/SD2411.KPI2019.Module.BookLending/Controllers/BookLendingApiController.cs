using Microsoft.AspNetCore.Mvc;
using SD2411.KPI2019.Module.BookLending.Model;
using SD2411.KPI2019.Module.BookLending.Services;
using SD2411.KPI2019.Module.Books.Services;
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
        private readonly IBookService _bookService;
        public BookLendingApiController(IBookLendingService bookLendingService, IBookService bookService)
        {
            this._bookLendingService = bookLendingService;
            this._bookService = bookService;
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
        public async Task<IActionResult> Get([FromRoute] string userid)
        {
            var result = await _bookLendingService.BooksBorrowedByUserAsync(userid);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Return a book that the user borrow
        /// </summary>
        /// <param name="id">The booklending Id</param>
        /// <returns></returns>
        [HttpPut("book-returning/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] BookLendingRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _bookLendingService.BookReturning(id, model);
            if (result)
            {
                return Accepted();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("book-lending")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Post([FromBody] BookLendingRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //Checking the book if it is available to Lend
            var bookDetail = await _bookService.GetByIdAsync(model.BookId);
            if (bookDetail == null)
            {
                return BadRequest();
            }
            if (!bookDetail.Available2Lend)
            {
                return NoContent();
            }

            // Lending a book
            var result = await _bookLendingService.BookLending(model);
            if (result != null)
            {
                // Update the field Available2Lend to False in Book
                _bookService.UpdateAvailable2Lend(bookDetail.Id, false);

                return Created(nameof(Post), result);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
