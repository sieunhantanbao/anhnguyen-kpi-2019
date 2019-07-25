using SD2411.KPI2019.Module.Core.Data;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD2411.KPI2019.Module.Users.Data
{
    public class UserRepository : Repository<UserAccount>, IUserRepository
    {
        public UserRepository(SD2411DBContext context): base(context)
        {

        }
    }
}
