using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Extensions;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Core.Data;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
namespace SD2411.KPI2019.Module.Users.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SD2411DBContext _context;
        public UserService(UserManager<ApplicationUser> userManager, SD2411DBContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<UserResponseDto> CreateAsync(UserRequestDto user)
        {
            var appUser = MapToRequest(user);
            var result = await _userManager.CreateAsync(appUser, user.Password);
            return MapToResponse(appUser);
        }

        public async Task<PaginatedItems<UserResponseDto, string>> ListAsync(int pageIndex, int pageSize)
        {
            var entityCount = _context.Users.Count();
            var appUsers  = await _context.Users.Paginate(pageIndex, pageSize).ToListAsync();
            var userDtos = MapToResponse(appUsers);
            return new PaginatedItems<UserResponseDto, string>(pageIndex, pageSize, entityCount, userDtos);
        }

        #region Private Methods
        private IEnumerable<UserResponseDto> MapToResponse(List<ApplicationUser> appUsers)
        {
            foreach (var item in appUsers)
            {
                yield return new UserResponseDto
                {
                    Email = item.Email,
                    FullName = item.FullName,
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                    UserName = item.UserName
                };
            }
        }
        private UserResponseDto MapToResponse(ApplicationUser appUser)
        {
                return new UserResponseDto
                {
                    Email = appUser.Email,
                    FullName = appUser.FullName,
                    Id = appUser.Id,
                    PhoneNumber = appUser.PhoneNumber,
                    UserName = appUser.UserName
                };
        }

        private ApplicationUser MapToRequest(UserRequestDto requestUser)
        {
            return new ApplicationUser
            {
                Email = requestUser.Email,
                FullName = requestUser.FullName,
                PhoneNumber = requestUser.PhoneNumber,
                UserName = requestUser.UserName
            };
        }
        #endregion
    }
}
