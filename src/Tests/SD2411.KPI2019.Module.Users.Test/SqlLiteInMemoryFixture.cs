using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SD2411.KPI2019.Module.Core.Data;
using SD2411.KPI2019.Module.Core.Model;
using System;

namespace SD2411.KPI2019.Module.Users.Test
{
    public class SqlLiteInMemoryFixture : IDisposable
    {
        private IServiceScope _serviceScope;
        private SqliteConnection _connection;

        public virtual void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            _serviceScope?.Dispose();
            _serviceScope = null;
        }

        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddLogging().AddDbContext<SD2411DBContext>(b => b.UseSqlite(_connection));
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<SD2411DBContext>()
               .AddUserManager<UserManager<ApplicationUser>>();
            return services;
        }
            

        public virtual IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceScope == null)
                {
                    _serviceScope = ConfigureServices(new ServiceCollection()).BuildServiceProvider().CreateScope();
                }

                return _serviceScope.ServiceProvider;
            }
        }

        public virtual SD2411DBContext Context => ServiceProvider.GetRequiredService<SD2411DBContext>();

        public virtual void CreateDatabase()
        {
            Dispose();
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
            Context.Database.EnsureCreated();
        }
    }
}
