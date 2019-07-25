using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Users.Data
{
    public interface IUserRepository : IRepository<UserAccount>
    {
    }
}
