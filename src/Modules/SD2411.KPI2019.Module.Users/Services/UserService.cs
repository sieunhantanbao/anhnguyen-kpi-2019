using System.Threading.Tasks;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.Users.Model;

namespace SD2411.KPI2019.Module.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserAccount> _repository;
        public UserService(IRepository<UserAccount> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserAccount> CreateUser(UserAccount user)
        {
            return await _repository.AddAsync(user);
        }
    }
}
