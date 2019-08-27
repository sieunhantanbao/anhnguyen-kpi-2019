using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Books.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.Books.Services
{
    public interface IBookService
    {
        // Book
        Task<BookResponseDto> GetByIdAsync(int id);
        Task<PaginatedItems<BookResponseDto, int>> ListAsync(int pageIndex, int pageSize);
        Task<BookResponseDto> CreateAsync(BookRequestDto book);
        BookResponseDto Update(int id, BookRequestDto book);
        void UpdateAvailable2Lend(int bookId, bool isAvailable2Lend);
        void Delete(int id);

        // Book Category
        Task<BookCategoryResponseDto> GetCatByIdAsync(int id);
        Task<PaginatedItems<BookCategoryResponseDto, int>> ListCatAsync(int pageIndex, int pageSize);
    }
}
