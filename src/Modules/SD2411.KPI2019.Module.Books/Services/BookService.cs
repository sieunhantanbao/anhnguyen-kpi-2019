using SD2411.KPI2019.Infrastructure.Data;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Books.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SD2411.KPI2019.Module.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Query;

namespace SD2411.KPI2019.Module.Books.Services
{
    public class BookService : IBookService
    {
        private readonly SD2411DBContext _context;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookCategory> _bookCatRepository;
        public BookService(IRepository<Book> bookRepo, IRepository<BookCategory> bookCatRepo)
        {
            _bookRepository = bookRepo;
            _bookCatRepository = bookCatRepo;
        }

        public async Task<BookResponseDto> CreateAsync(BookRequestDto book)
        {
            var bookEntity = MapToRequest(book);
            var result = await _bookRepository.AddAsync(bookEntity);
            return MapToResponse(result);
        }

        public void Delete(int id)
        {
            _bookRepository.Remove(_GetById(id));
        }

        public async Task<BookResponseDto> GetByIdAsync(int id)
        {
            var result = await _bookRepository.FindByIdAsync(id, IncludeProperties);
            return MapToResponse(result);
        }

        public async Task<BookCategoryResponseDto> GetCatByIdAsync(int id)
        {
            var result = await _bookCatRepository.FindByIdAsync(id);
            return MapToResponse(result);
        }

        public async Task<PaginatedItems<BookResponseDto, int>> ListAsync(int pageIndex, int pageSize)
        {
            var result = await _bookRepository.ListAsync(pageIndex, pageSize, null, null, IncludeProperties);
            return MapToResponse(result);
        }

        public async Task<PaginatedItems<BookCategoryResponseDto, int>> ListCatAsync(int pageIndex, int pageSize)
        {
            var result = await _bookCatRepository.ListAsync(pageIndex, pageSize);
            return MapToResponse(result);
        }

        public BookResponseDto Update(int id, BookRequestDto book)
        {
            var bookEntity = _GetById(id);
            bookEntity.Author = book.Author;
            bookEntity.Available2Lend = book.Available2Lend;
            bookEntity.Description = book.Description;
            bookEntity.Name = book.Name;
            bookEntity.Language = book.Language;
            bookEntity.PublishedDate = book.PublishedDate;
            bookEntity.ISBN = book.ISBN;
            bookEntity.ISBN13 = book.ISBN13;
            bookEntity.Weight = book.Weight;
            bookEntity.Length = book.Length;
            bookEntity.Dimensions = book.Dimensions;
            bookEntity.ImageUrl = book.ImageUrl;
            _bookRepository.Update(bookEntity);

            return MapToResponse(bookEntity);
        }

        public void UpdateAvailable2Lend(int bookId, bool isAvailable2Lend)
        {
            var bookEntity = _GetById(bookId);
            if (bookEntity != null)
            {
                bookEntity.Available2Lend = isAvailable2Lend;
                _bookRepository.Update(bookEntity);
            }
        }
        #region Private methods
        private Book _GetById(int id)
        {
            return _bookRepository.FindByIdAsync(id, IncludeProperties)?.Result;
        }
        private BookCategory _GetCatById(int id)
        {
            return  _bookCatRepository.FindByIdAsync(id)?.Result;
        }
        private IEnumerable<BookResponseDto> MapToResponse(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                yield return new BookResponseDto
                {
                    Id = book.Id,
                    Author = book.Author,
                    Available2Lend = book.Available2Lend,
                    CatId = book.BookCategory?.Id,
                    CatName = book.BookCategory?.Name,
                    Description = book.Description,
                    Language = book.Language,
                    ISBN = book.ISBN,
                    ISBN13 = book.ISBN13,
                    Dimensions = book.Dimensions,
                    Length = book.Length,
                    Weight = book.Weight,
                    Name = book.Name,
                    ImageUrl = book.ImageUrl,
                    PublishedDate = book.PublishedDate
                };
            }
        }
        private BookResponseDto MapToResponse(Book book)
        {
            if (book != null)
            {
                return new BookResponseDto
                {
                    Id = book.Id,
                    Author = book.Author,
                    Available2Lend = book.Available2Lend,
                    Language = book.Language,
                    ISBN = book.ISBN,
                    ISBN13 = book.ISBN13,
                    Dimensions = book.Dimensions,
                    Length = book.Length,
                    Weight = book.Weight,
                    CatId = book.BookCategory.Id,
                    CatName = book.BookCategory?.Name,
                    Description = book.Description,
                    Name = book.Name,
                    ImageUrl = book.ImageUrl,
                    PublishedDate = book.PublishedDate
                };
            }
            return null;
        }

        private PaginatedItems<BookResponseDto, int> MapToResponse(PaginatedItems<Book, int> books)
        {
            return new PaginatedItems<BookResponseDto, int>(books.PageIndex, books.PageSize, books.Count, MapToResponse(books.Data));
        }
        private Book MapToRequest(BookRequestDto book)
        {
            if (book != null)
            {
                return new Book
                {
                    Id = book.Id,
                    Author = book.Author,
                    Available2Lend = book.Available2Lend,
                    Description = book.Description,
                    Name = book.Name,
                    Language = book.Language,
                    ISBN = book.ISBN,
                    ISBN13 = book.ISBN13,
                    Dimensions = book.Dimensions,
                    Length = book.Length,
                    Weight = book.Weight,
                    PublishedDate = book.PublishedDate,
                    ImageUrl = book.ImageUrl,
                    BookCategory = _GetCatById(book.CatId)
                };

            }
            return null;
        }
        private IEnumerable<BookCategoryResponseDto> MapToResponse(IEnumerable<BookCategory> bookCats)
        {
            foreach (var bookCat in bookCats)
            {
                yield return new BookCategoryResponseDto
                {
                    Id = bookCat.Id,
                    Description = bookCat.Description,
                    Name = bookCat.Name
                };
            }
        }

        private BookCategoryResponseDto MapToResponse(BookCategory bookCat)
        {
            if (bookCat != null)
            {
                return new BookCategoryResponseDto
                {
                    Id = bookCat.Id,
                    Description = bookCat.Description,
                    Name = bookCat.Name
                };
            }
            return null;
        }
        private PaginatedItems<BookCategoryResponseDto, int> MapToResponse(PaginatedItems<BookCategory, int> bookCats)
        {
            return new PaginatedItems<BookCategoryResponseDto, int>(bookCats.PageIndex, bookCats.PageSize, bookCats.Count, MapToResponse(bookCats.Data));
        }

        private IIncludableQueryable<Book, object> IncludeProperties(IQueryable<Book> book)
        {
            return book.Include(c => c.BookCategory);
        }
        #endregion
    }
}
