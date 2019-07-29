using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SD2411.KPI2019.Infrastructure.Modules;
using SD2411.KPI2019.Module.Users.Data;
using SD2411.KPI2019.Module.Users.Services;
using System;

namespace SD2411.KPI2019.Module.Users
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            //services.AddSingleton(typeof(IUserService), typeof(UserService));
        }
    }
}
