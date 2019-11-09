using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SD2411.KPI2019.Module.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Core.Data
{
    public class SeedData
    {
        private static readonly string UserId = "69016cd7-609d-4539-a786-af8475f8c624";
        private static readonly string Password = "Admin123!@#";
        private static readonly string AdminEmail = "sieunhantanbao@gmail.com";
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SD2411DBContext>();
            await CreateUsers(serviceProvider, context);
        }

        private async static Task CreateUsers(IServiceProvider serviceProvider, SD2411DBContext context)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            // Create admin User
            var user = await userManager.FindByEmailAsync(AdminEmail);
            if (user == null)
            {
                ApplicationUser adminUser = new ApplicationUser
                {
                    Id = UserId,
                    Email = AdminEmail,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "administrator",
                    FullName = "Nguyen Sieu Anh",
                    PhoneNumber = "+84 985 413 357"
                };
                await userManager.CreateAsync(adminUser, Password);
            }
            // Create Test User
            foreach (var userTest in SampleUsers())
            {
                var userTestExisted = await userManager.FindByEmailAsync(userTest.Email);
                if (userTestExisted == null)
                {
                    await userManager.CreateAsync(userTest, Password);
                }
            }
        }

        private static List<ApplicationUser> SampleUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test.user1@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "testuser1",
                    FullName = "Test User 1",
                    PhoneNumber = "+84 000 111 222"
                },
                 new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test.user2@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "testuser2",
                    FullName = "Test User 2",
                    PhoneNumber = "+84 444 555 666"
                }
            };
        }
    }
}
