using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SD2411.KPI2019.Module.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class SeedData
    {
        private static readonly string Password = "Admin123!@#";
        private static readonly string AdminEmail = "sieunhantanbao@gmail.com";
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SD2411DBContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            var user = await userManager.FindByEmailAsync(AdminEmail);
            if (user == null)
            {
                ApplicationUser adminUser = new ApplicationUser
                {
                    Email = AdminEmail,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "administrator"
                };
                await userManager.CreateAsync(adminUser, Password);
            }
        }
    }
}
