using Microsoft.AspNetCore.Identity;
using SD2411.KPI2019.Infrastructure.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Core.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
