using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SD2411.KPI2019.HostStandard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("testing");
        }
    }
}