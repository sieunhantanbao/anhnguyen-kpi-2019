using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Users.Services
{
    public interface IUserService
    {
        Task<UserAccount> CreateUser(UserAccount user);
    }
}
