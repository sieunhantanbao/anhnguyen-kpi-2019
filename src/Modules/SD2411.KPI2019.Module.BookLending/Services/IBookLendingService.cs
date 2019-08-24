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
       //  Task<BookLendingResponseDto> GetByIdAsync(int id);
        Task<BooksBorrowedByUserResponseDto> BooksBorrowedByUserAsync(string userId);
        //Task<BookLendingResponseDto> CreateAsync(BookLendingRequestDto book);
        //BookLendingResponseDto Update(int id, BookLendingRequestDto book);
        //void Delete(int id);
    }
}
