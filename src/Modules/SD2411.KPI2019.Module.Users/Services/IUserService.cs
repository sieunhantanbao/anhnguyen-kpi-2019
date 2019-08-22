using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Users.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateAsync(UserRequestDto user);
        Task<PaginatedItems<UserResponseDto, string>> ListAsync(int pageIndex, int pageSize);
    }
}
