using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Infrastructure.Extensions;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Core.Data;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            await _userManager.CreateAsync(appUser, user.Password);
            return MapToResponse(appUser);
        }
        public async Task<UserResponseDto> UpdateAsync(string id, UserRequestDto user)
        {
            var appUser = await _GetByIdAsync(id);
            if (appUser != null)
            {
                appUser.UserName = user.UserName;
                appUser.FullName = user.FullName;
                appUser.PhoneNumber = user.PhoneNumber;

                _context.Users.Update(appUser);
                _context.SaveChanges();
            }
            return appUser != null ? MapToResponse(appUser) : new UserResponseDto();

        }
        public async Task DeleteAsync(string id)
        {
            var appUser = await _GetByIdAsync(id);
            var deleted = _context.Users.Remove(appUser);
            _context.SaveChanges();
        }

        public async Task<UserResponseDto> GetByIdAsync(string id)
        {
            var appUser = await _GetByIdAsync(id);
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
        private async Task<ApplicationUser> _GetByIdAsync(string id)
        {
            var appUser = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return appUser;
        }
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
            if (appUser != null)
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
            return null;  
        }

        private ApplicationUser MapToRequest(UserRequestDto requestUser)
        {
            if (requestUser != null)
            {
                return new ApplicationUser
                {
                    Email = requestUser.Email,
                    FullName = requestUser.FullName,
                    PhoneNumber = requestUser.PhoneNumber,
                    UserName = requestUser.UserName
                };
            }
            return null;
        }
        #endregion
    }
}
