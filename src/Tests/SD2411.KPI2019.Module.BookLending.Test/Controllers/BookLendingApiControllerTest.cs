using Moq;
using SD2411.KPI2019.Module.BookLending.Controllers;
using SD2411.KPI2019.Module.BookLending.Model;
using SD2411.KPI2019.Module.BookLending.Services;
using SD2411.KPI2019.Module.Books.Model;
using SD2411.KPI2019.Module.Books.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SD2411.KPI2019.Module.BookLending.Test.Controllers
{
    public class BookLendingApiControllerTest
    {
        private readonly Mock<IBookLendingService> _bookLendingServiceMock;
        private readonly Mock<IBookService> _bookServiceMock;
        private BookLendingApiController _bookLendingApiController;
        public BookLendingApiControllerTest()
        {
            _bookLendingServiceMock = new Mock<IBookLendingService>();
            _bookServiceMock = new Mock<IBookService>();
        }

        [Fact(DisplayName = "GetBorrowedBook_ByUser_Success")]
        public async Task GetBorrowedBook_ByUser_Success()
        {
            // Arrange
            var userId = "1";
            var booksBorrowedByUserResponseDtos = new BooksBorrowedByUserResponseDto()
            {
                User = new Users.Model.UserResponseDto
                {
                    Id = userId,
                    Email = "test.email@email.test",
                    FullName = "Test User",
                    UserName = "test"
                },
                Books = new List<BookLendingResponseDto> {
                   new BookLendingResponseDto
                   {
                       Id = 1,
                       Name = "Book 1",
                       PublishedDate = new DateTime(2019,1,1)
                   },
                   new BookLendingResponseDto
                   {
                       Id = 2,
                       Name = "Book 2",
                       PublishedDate = new DateTime(2018,1,1)
                   }
               }
            };
            
            _bookLendingServiceMock.Setup(c => c.BooksBorrowedByUserAsync(userId)).ReturnsAsync(booksBorrowedByUserResponseDtos);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Get(userId);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            var resultStatus = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.OK, resultStatus);
            Assert.Equal(booksBorrowedByUserResponseDtos, resultValue);
        }

        [Fact(DisplayName = "GetBorrowedBook_InvalidUser_NoContent")]
        public async Task GetBorrowedBook_InvalidUser_NoContent()
        {
            // Arrange
            var userId = "-1";

            _bookLendingServiceMock.Setup(c => c.BooksBorrowedByUserAsync(userId)).ReturnsAsync((BooksBorrowedByUserResponseDto)null);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Get(userId);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }

        [Fact(DisplayName = "ReturnBook_BookLendingId_Accepted")]
        public async Task ReturnBook_BookLendingId_Accepted()
        {
            // Arrange
            var returnResult = true;
            var bookLendingId = 1;
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = 1,
                Id = bookLendingId,
                UserId = "2"
            };

            _bookLendingServiceMock.Setup(c => c.BookReturning(bookLendingId, bookLendingRequest)).ReturnsAsync(returnResult);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Put(bookLendingId, bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.AcceptedResult)result).StatusCode;
            var resultValue = ((Microsoft.AspNetCore.Mvc.AcceptedResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Accepted, resultStatus);
            Assert.Equal(returnResult, resultValue);
        }

        [Fact(DisplayName = "ReturnBook_BookLendingId_NoContent")]
        public async Task ReturnBook_BookLendingId_NoContent()
        {
            // Arrange
            var returnResult = false;
            var bookLendingId = 1;
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = 1,
                Id = bookLendingId,
                UserId = "2"
            };

            _bookLendingServiceMock.Setup(c => c.BookReturning(bookLendingId, bookLendingRequest)).ReturnsAsync(returnResult);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Put(bookLendingId, bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.NoContentResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }

        [Fact(DisplayName = "BorrowABook_BookNotExist_BadRequest")]
        public async Task BorrowABook_BookNotExist_BadRequest()
        {
            // Arrange
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = 1,
                Id = 1,
                UserId = "2"
            };

            _bookServiceMock.Setup(c => c.GetByIdAsync(bookLendingRequest.BookId)).ReturnsAsync((BookResponseDto)null);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Post(bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.BadRequestResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.BadRequest, resultStatus);
        }

        [Fact(DisplayName = "BorrowABook_BookExistButNotAvailToBorrow_NoContent")]
        public async Task BorrowABook_BookExistButNotAvailToBorrow_NoContent()
        {
            // Arrange
            var bookId = 1;
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = bookId,
                Id = 1,
                UserId = "2"
            };

            var bookInfo = new BookResponseDto
            {
                Id = bookId,
                Name = "Book 1",
                PublishedDate = new DateTime(2015, 10, 1),
                Available2Lend = false
            };

            _bookServiceMock.Setup(c => c.GetByIdAsync(bookLendingRequest.BookId)).ReturnsAsync(bookInfo);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Post(bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.NoContentResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }

        [Fact(DisplayName = "BorrowABook_BookExist_Success")]
        public async Task BorrowABook_BookExist_Success()
        {
            // Arrange
            var bookId = 1;
            var userId = "2";
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = bookId,
                Id = 1,
                UserId = userId
            };

            var bookInfo = new BookResponseDto
            {
                Id = bookId,
                Name = "Book 1",
                PublishedDate = new DateTime(2015, 10, 1),
                Available2Lend = true
            };

            var bookLendingResponse = new BookLendingResponseDto
            {
                BookId = bookId,
                Id = 1,
                PublishedDate = new DateTime(2010, 1, 1),
                UserId = userId
            };

            _bookServiceMock.Setup(c => c.GetByIdAsync(bookLendingRequest.BookId)).ReturnsAsync(bookInfo);
            _bookLendingServiceMock.Setup(c => c.BookLending(bookLendingRequest)).ReturnsAsync(bookLendingResponse);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Post(bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.CreatedResult)result).StatusCode;
            var resultValue = ((Microsoft.AspNetCore.Mvc.CreatedResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Created, resultStatus);
            Assert.Equal(bookLendingResponse, resultValue);
        }
        [Fact(DisplayName = "BorrowABook_BookExistFailedToBorrow_NoContent")]
        public async Task BorrowABook_BookExistFailedToBorrow_NoContent()
        {
            // Arrange
            var bookId = 1;
            var userId = "2";
            var bookLendingRequest = new BookLendingRequestDto
            {
                BookId = bookId,
                Id = 1,
                UserId = userId
            };

            var bookInfo = new BookResponseDto
            {
                Id = bookId,
                Name = "Book 1",
                PublishedDate = new DateTime(2015, 10, 1),
                Available2Lend = true
            };

            _bookServiceMock.Setup(c => c.GetByIdAsync(bookLendingRequest.BookId)).ReturnsAsync(bookInfo);
            _bookLendingServiceMock.Setup(c => c.BookLending(bookLendingRequest)).ReturnsAsync((BookLendingResponseDto)null);
            _bookLendingApiController = new BookLendingApiController(_bookLendingServiceMock.Object, _bookServiceMock.Object);
            // Act
            var result = await _bookLendingApiController.Post(bookLendingRequest);
            // Assert
            var resultStatus = ((Microsoft.AspNetCore.Mvc.NoContentResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatus);
        }
    }
}
