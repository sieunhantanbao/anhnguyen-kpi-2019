using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SD2411.KPI2019.Infrastructure.Modules;
using SD2411.KPI2019.Module.Books.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Books
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IBookService), typeof(BookService));
        }
    }
}
