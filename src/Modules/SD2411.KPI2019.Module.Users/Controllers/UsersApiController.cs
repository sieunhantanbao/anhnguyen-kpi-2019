using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Users.Controllers
{
    // [Route("api/users")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}
