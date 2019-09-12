using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Helpers;
using SD2411.KPI2019.Module.BookLending.Model;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Module.BookLending.Services
{
    public class BookLendingService : IBookLendingService
    {
        private readonly IRepository<Model.BookLending> _bookLendingRepository;
        private readonly RestInvoker _restInvoke;
        public BookLendingService(IRepository<Model.BookLending> bookLendingRepository, RestInvoker restInvoke)
        {
            _bookLendingRepository = bookLendingRepository;
            _restInvoke = restInvoke;
        }
        public async Task<BooksBorrowedByUserResponseDto> BooksBorrowedByUserAsync(string userId)
        {
            var result = await _bookLendingRepository.ListAsync(c => c.AppUser.Id == userId, order => order.OrderBy(c => c.BorrowDate), IncludeProperties);
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

        public async Task<bool> BookReturning(int id, BookLendingRequestDto bookLendingRes)
        {
            var bookLendingToReturn = await _GetByIdAsync(id);

            // Could not find the bookLending record 
            // OR the book has been returned
            // OR the bookToReturn does not belong to the user
            // OR the book has Available2Lend is TRUE
            if (bookLendingToReturn == null
                || bookLendingToReturn.ReturnDate != null
                || bookLendingToReturn.UserId != bookLendingRes.UserId
                || bookLendingToReturn.Book.Available2Lend)
            {
                return false;
            }

            // Update the ReturnDate and the Available to lend to TRUE
            bookLendingToReturn.ReturnDate = DateTime.UtcNow;
            bookLendingToReturn.Book.Available2Lend = true;

            _bookLendingRepository.Update(bookLendingToReturn);

            return true;
        }

        public async Task<BookLendingResponseDto> BookLending(BookLendingRequestDto bookLending)
        {
            var bookLendingEntityRequest = MapToRequest(bookLending);
            // Create record in book_lending
            var bookLendingEntityResponse =  await _bookLendingRepository.AddAsync(bookLendingEntityRequest);
            // Update the field Available2Lend to False
            var insertedBookLending = await _bookLendingRepository.FindByIdAsync(bookLendingEntityResponse.Id, IncludeProperties);

            return MapToResponse(insertedBookLending);
        }
        #region Private Methods
        private async Task<Model.BookLending> _GetByIdAsync(int id)
        {
            return await _bookLendingRepository.FindByIdAsync(id, IncludeProperties);
        }
        private IEnumerable<BookLendingResponseDto> MapToResponse(IEnumerable<Model.BookLending> bookLendings)
        {
            foreach (var bookLending in bookLendings)
            {
                yield return MapToResponse(bookLending);
            }
        }

        private BookLendingResponseDto MapToResponse(Model.BookLending bookLending)
        {
            if (bookLending != null)
            {
                return new BookLendingResponseDto
                {
                    Id = bookLending.Id,
                    UserId = bookLending.UserId,
                    BookId = bookLending.Book.Id,
                    BookSlug = bookLending.Book.Slug,
                    Author = bookLending.Book.Author,
                    Description = bookLending.Book.Description,
                    CategoryName = bookLending.Book.BookCategory?.Name,
                    Name = bookLending.Book.Name,
                    PublishedDate = bookLending.Book.PublishedDate,
                    BorrowDate = bookLending.BorrowDate,
                    ReturnDate = bookLending.ReturnDate
                };
            }
            return null;
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

        private Model.BookLending MapToRequest(BookLendingRequestDto request)
        {
            if (request != null)
            {
                return new Model.BookLending
                {
                    BookId = request.BookId,
                    UserId = request.UserId,
                    BorrowDate = DateTime.UtcNow,
                    ReturnDate = null,
                    Id = request.Id
                };
            }
            return null;
        }
        private IIncludableQueryable<Model.BookLending, object> IncludeProperties(IQueryable<Model.BookLending> bookLending)
        {
            return bookLending.Include(c => c.AppUser).Include(c => c.Book).ThenInclude(c => c.BookCategory);
        }
        #endregion
    }
}
