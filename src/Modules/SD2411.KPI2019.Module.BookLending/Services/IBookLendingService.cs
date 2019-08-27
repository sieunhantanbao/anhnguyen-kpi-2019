using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.BookLending.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.BookLending.Services
{
    public interface IBookLendingService
    {
        Task<BooksBorrowedByUserResponseDto> BooksBorrowedByUserAsync(string userId);
        Task<bool> BookReturning(int id, BookLendingRequestDto model);
        Task<BookLendingResponseDto> BookLending(BookLendingRequestDto model);
    }
}
