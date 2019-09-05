using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Users.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Users.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class UsersApiController : Controller
    {
        private readonly IUserService _userService;
        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get list user with paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedItems<UserResponseDto, string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
        {
            return Ok(await _userService.ListAsync(pageIndex, pageSize));
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UserResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var result = await _userService.GetByIdAsync(id);
            if(result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UserResponseDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]UserRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Created(nameof(Get), await _userService.CreateAsync(user));
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] UserRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.UpdateAsync(id, user);

            return Accepted();
        }
        /// <summary>
        /// Delete user by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _userService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Get my profile from token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("my-profile")]
        [ProducesResponseType(typeof(UserResponseDto),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var userId = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            var result  = await _userService.GetByIdAsync(userId);
            return Ok(result);
        }
    }
}
