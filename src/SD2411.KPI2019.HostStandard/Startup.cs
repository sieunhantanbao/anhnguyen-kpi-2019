using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SD2411.KPI2019.Infrastructure;
using SD2411.KPI2019.Infrastructure.Extensions;
using SD2411.KPI2019.Module.Core.Data;
using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Modules;
using System.IO;
using Microsoft.OpenApi.Models;
using SD2411.KPI2019.HostStandard.Extension;
using SD2411.KPI2019.Infrastructure.Helpers;

namespace SD2411.KPI2019.HostStandard
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Get GlobalConfiguration information
            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;

            services.AddScoped(typeof(DbContext), typeof(SD2411DBContext));
            // Add modules
            services.AddModules(new DirectoryInfo(_hostingEnvironment.ContentRootPath).Parent.FullName);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Register database
            services.AddDbContextPool<SD2411DBContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                    c => c.MigrationsAssembly("SD2411.KPI2019.HostStandard"));
            });

            // Register common Services
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypeId<,>));

            // Add Custome MVC (API for all modules)
            services.AddCustomizedMvc(GlobalConfiguration.Modules);

            // Register services from Module
            var sp = services.BuildServiceProvider();
            var moduleInitilizers = sp.GetServices<IModuleInitializer>();
            foreach (var moduleInitilizer in moduleInitilizers)
            {
                moduleInitilizer.ConfigureServices(services);
            }
            // Add cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SD2411 KPI API", Version = "v1" });
            });

            //services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
            // Use Custom MVC (API) modules
            app.UseCustomizedMvc();

            // Use Cors
            app.UseCors("AllowAnyOrigin");

            // Use Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SD2411 KPI V1 Docs");

            });

            //app.UseCors(builder => builder
            //        .AllowAnyOrigin()
            //        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS", "PATCH", "HEAD", "CONNECT", "TRACE")
            //        .AllowAnyHeader()
            //        .AllowCredentials());
        }
    }
}
