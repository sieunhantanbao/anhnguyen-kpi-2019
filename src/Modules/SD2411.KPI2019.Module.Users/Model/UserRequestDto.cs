﻿using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Users.Model
{
    public class UserRequestDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}