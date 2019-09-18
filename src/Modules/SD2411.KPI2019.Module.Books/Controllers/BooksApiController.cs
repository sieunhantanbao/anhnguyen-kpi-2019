using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Books.Model;
using SD2411.KPI2019.Module.Books.Services;
using System.Net;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Books.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class BooksApiController : Controller
    {
        private readonly IBookService _bookService;
        public BooksApiController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get list books with paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedItems<BookResponseDto, int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
        {
            return Ok(await _bookService.ListAsync(pageIndex, pageSize));
        }
        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BookResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            BookResponseDto result;
            int.TryParse(id, out int bookId);
            if (bookId > 0)
            {
                result = await _bookService.GetByIdAsync(bookId);
            }
            else
            {
                result = await _bookService.GetBySlugAsync(id);
            }
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
        /// Create book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BookResponseDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]BookRequestDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Created(nameof(Get), await _bookService.CreateAsync(book));
        }

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public IActionResult Put([FromRoute] int id, [FromBody] BookRequestDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _bookService.Update(id, book);

            return Accepted(result);
        }
        /// <summary>
        /// Delete book by book Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromRoute] int id)
        {
             _bookService.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Get list cats with paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("cats")]
        [ProducesResponseType(typeof(PaginatedItems<BookCategoryResponseDto, int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCats([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
        {
            return Ok(await _bookService.ListCatAsync(pageIndex, pageSize));
        }
        /// <summary>
        /// Get book cat by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("cat/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BookCategoryResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetCat([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var result = await _bookService.GetCatByIdAsync(id);
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
