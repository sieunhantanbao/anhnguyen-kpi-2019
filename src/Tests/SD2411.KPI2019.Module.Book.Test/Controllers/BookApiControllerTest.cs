using Moq;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Books.Controllers;
using SD2411.KPI2019.Module.Books.Model;
using SD2411.KPI2019.Module.Books.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SD2411.KPI2019.Module.Book.Test.Controllers
{
    public class BookApiControllerTest
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private BooksApiController _booksApiController;
        public BookApiControllerTest()
        {
            _bookServiceMock = new Mock<IBookService>();
        }

        [Fact(DisplayName = "GetListBooks_WithPaging_Success")]
        public async Task GetListBooks_WithPaging_Success()
        {
            // Arrange
            var pageIndex = 0;
            var pageSize = 10;
            var bookResponseDtos = new List<BookResponseDto>()
            {
                new BookResponseDto
                {
                    Id = 1,
                    Name = "Book 1",
                    ISBN = "453464567657"
                },
                new BookResponseDto
                {
                    Id = 2,
                    Name = "Book 2",
                    ISBN = "243547645664"
                }
            };
            var listBooks = new PaginatedItems<BookResponseDto, int>(pageIndex, pageSize, bookResponseDtos.Count, bookResponseDtos);
            _bookServiceMock.Setup(c => c.ListAsync(pageIndex, pageSize)).ReturnsAsync(listBooks);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Get(pageIndex, pageSize);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(listBooks, resultValue);
        }

        [Fact(DisplayName = "GetBook_ById_Success")]
        public async Task GetBook_ById_Success()
        {
            var bookIdStr = "2";
            var bookResponseDtos = new BookResponseDto
            {
                Id = int.Parse(bookIdStr),
                Name = "Book 2",
                ISBN = "243547645664"
            };
            _bookServiceMock.Setup(c => c.GetByIdAsync(bookResponseDtos.Id)).ReturnsAsync(bookResponseDtos);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Get(bookIdStr);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(bookResponseDtos, resultValue);
        }
        [Fact(DisplayName = "GetBook_BySlug_Success")]
        public async Task GetBook_BySlug_Success()
        {
            var bookSlug = Guid.NewGuid().ToString();
            var bookResponseDtos = new BookResponseDto
            {
                Id = 3,
                Name = "Book 3",
                ISBN = "243547645664"
            };
            _bookServiceMock.Setup(c => c.GetBySlugAsync(bookSlug)).ReturnsAsync(bookResponseDtos);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Get(bookSlug);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(bookResponseDtos, resultValue);
        }

        [Fact(DisplayName = "GetBook_Null_BadRequest")]
        public async Task GetBook_Null_BadRequest()
        {
            string bookSlug = null;
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Get(bookSlug);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.BadRequest, resultStatus);
        }

        [Fact(DisplayName = "GetBook_BookId_NoContent")]
        public async Task GetBook_BookId_NoContent()
        {
            string bookId = "1";
            _bookServiceMock.Setup(c => c.GetByIdAsync(int.Parse(bookId))).ReturnsAsync((BookResponseDto)null);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Get(bookId);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }

        [Fact(DisplayName = "CreateBook_ValidBook_Success")]
        public async Task CreateBook_ValidBook_Success()
        {
            // Arrange
            var bookRequestDtos = new BookRequestDto
            {
                Id = 0,
                Name = "Book 1",
                CatId = 1,
                ISBN = "1213244234"
            };
            var bookResponseDtos = new BookResponseDto
            {
                Id = 100,
                Name = "Book 1",
                CatId = 1,
                ISBN = "1213244234"
            };
            _bookServiceMock.Setup(c => c.CreateAsync(bookRequestDtos)).ReturnsAsync(bookResponseDtos);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.Post(bookRequestDtos);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            var resultValue = (BookResponseDto)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Created, resultStatusCode);
            Assert.Equal(bookResponseDtos, resultValue);
        }

        [Fact(DisplayName = "UpdateBook_ValidBook_Success")]
        public void UpdateBook_ValidBook_Success()
        {
            // Arrange
            var bookRequestDtos = new BookRequestDto
            {
                Id = 100,
                Name = "Book 2",
                CatId = 1,
                ISBN = "1213244234",
                PublishedDate = new DateTime(2019, 10, 1)
            };
            var bookResponseDtos = new BookResponseDto
            {
                Id = 100,
                Name = "Book 2",
                CatId = 1,
                ISBN = "1213244234",
                PublishedDate = new DateTime(2019, 11, 1)
            };
            _bookServiceMock.Setup(c => c.Update(bookRequestDtos.Id, bookRequestDtos)).Returns(bookResponseDtos);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = _booksApiController.Put(bookRequestDtos.Id, bookRequestDtos);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Accepted, resultStatusCode);
            Assert.Equal(bookResponseDtos, resultValue);
        }

        [Fact(DisplayName = "DeleteBook_BookId_SuccessNoContent")]
        public void DeleteBook_BookId_SuccessNoContent()
        {
            // Arrange
            var bookId = 1;
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = _booksApiController.Delete(bookId);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatusCode);
        }

        [Fact(DisplayName = "GetListBookCats_WithPaging_Success")]
        public async Task GetListBookCats_WithPaging_Success()
        {
            // Arrange
            var pageIndex = 0;
            var pageSize = 10;
            var catsResponseDtos = new List<BookCategoryResponseDto>()
            {
                new BookCategoryResponseDto
                {
                    Id = 1,
                    Name = "Category 1"
                },
                new BookCategoryResponseDto
                {
                    Id = 2,
                    Name = "Category 2"
                }
            };
            var listCats = new PaginatedItems<BookCategoryResponseDto, int>(pageIndex, pageSize, catsResponseDtos.Count, catsResponseDtos);
            _bookServiceMock.Setup(c => c.ListCatAsync(pageIndex, pageSize)).ReturnsAsync(listCats);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.GetCats(pageIndex, pageSize);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(listCats, resultValue);
        }

        [Fact(DisplayName = "GetCat_ById_Success")]
        public async Task GetCat_ById_Success()
        {
            var catResponseDtos = new BookCategoryResponseDto
            {
                Id = 1,
                Name = "Category 1"
            };
            _bookServiceMock.Setup(c => c.GetCatByIdAsync(catResponseDtos.Id)).ReturnsAsync(catResponseDtos);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.GetCat(catResponseDtos.Id);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(catResponseDtos, resultValue);
        }
        [Fact(DisplayName = "GetCat_Null_BadRequest")]
        public async Task GetCat_Null_BadRequest()
        {
            int catId = 0;
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.GetCat(catId);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.BadRequest, resultStatus);
        }

        [Fact(DisplayName = "GetCat_CatId_NoContent")]
        public async Task GetCat_CatId_NoContent()
        {
            int catId = 1000;
            _bookServiceMock.Setup(c => c.GetCatByIdAsync(catId)).ReturnsAsync((BookCategoryResponseDto)null);
            _booksApiController = new BooksApiController(_bookServiceMock.Object);
            // Act
            var result = await _booksApiController.GetCat(catId);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }
    }
}
