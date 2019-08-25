using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Module.BookLending.Model;
using System.Linq;
using SD2411.KPI2019.Module.Books.Model;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Core.Model;

namespace SD2411.KPI2019.Module.BookLending.Services
{
    public class BookLendingService : IBookLendingService
    {
        private readonly IRepository<Model.BookLending> _bookLendingRepository;
        public BookLendingService(IRepository<Model.BookLending> bookLendingRepository)
        {
            _bookLendingRepository = bookLendingRepository;
        }
        public async Task<BooksBorrowedByUserResponseDto> BooksBorrowedByUserAsync(string userId)
        {
            var result = await _bookLendingRepository.ListAsync(c => c.AppUser.Id == userId, order => order.OrderBy(c=>c.BorrowDate), IncludeProperties);
            if (result == null || !result.Any())
            {
                return null;
            }
            var booksBorrowing = new BooksBorrowedByUserResponseDto
            {
                Books = MapToResponse(result),
                User = MapToResponse(result.Select(c => c.AppUser).FirstOrDefault())
            };
            return booksBorrowing;
        }

        #region Private Methods
        private IEnumerable<BookLendingResponseDto> MapToResponse(IEnumerable<Model.BookLending> bookLendings)
        {
            foreach (var bookLending in bookLendings)
            {
                yield return new BookLendingResponseDto
                {
                    Id = bookLending.Book.Id,
                    Author = bookLending.Book.Author,
                    Description = bookLending.Book.Description,
                    CategoryName = bookLending.Book.BookCategory?.Name,
                    Name = bookLending.Book.Name,
                    PublishedDate = bookLending.Book.PublishedDate,
                    BorrowDate = bookLending.BorrowDate,
                    ReturnDate = bookLending.ReturnDate
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
        private IIncludableQueryable<Model.BookLending, object> IncludeProperties(IQueryable<Model.BookLending> bookLending)
        {
            return bookLending.Include(c => c.AppUser).Include(c => c.Book).ThenInclude(c=>c.BookCategory);
        }
        #endregion
    }
}
