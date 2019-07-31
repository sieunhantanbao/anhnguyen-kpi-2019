﻿using Microsoft.AspNetCore.Mvc;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Users.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = new UserAccount
            {
                UserName = "Nguyen Sieu Anh 2"
            };
            return Ok(await _userService.CreateUser(user));
        }
    }
}
