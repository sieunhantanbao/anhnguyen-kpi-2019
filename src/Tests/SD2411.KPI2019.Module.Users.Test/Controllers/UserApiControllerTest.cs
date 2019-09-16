using Moq;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Users.Controllers;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Users.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SD2411.KPI2019.Module.Users.Test.Controllers
{
    public class UserApiControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private UsersApiController _usersApiController;
        public UserApiControllerTest()
        {
            this._userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task GetListUsers_WithPaging_Success()
        {
            // Arrange
            var userResponseDtos = new List<UserResponseDto>()
            {
                new UserResponseDto
                {
                    Id = "1",
                    Email = "test.email1@test.com",
                    FullName = "Test 1",
                    UserName = "User Name 1"
                },
                new UserResponseDto
                {
                    Id = "2",
                    Email = "test.email2@test.com",
                    FullName = "Test 2",
                    UserName = "User Name 2"
                }
            };
            var listUsers = new PaginatedItems<UserResponseDto, string>(0, 10, 2, userResponseDtos);
            _userServiceMock.Setup(c => c.ListAsync(0, 10)).ReturnsAsync(listUsers);
            _usersApiController = new UsersApiController(_userServiceMock.Object);
            // Act
            var result = await _usersApiController.Get(0,10);
            // Assert
            var okResultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.NotNull(result);
            Assert.Equal(listUsers, okResultValue);
        }

        [Fact]
        public async Task GetUser_ById_Success()
        {
            var userResponseDtos = new UserResponseDto
            {
                    Id = "1",
                    Email = "test.email1@test.com",
                    FullName = "Test 1",
                    UserName = "User Name 1"
            };
            _userServiceMock.Setup(c => c.GetByIdAsync(userResponseDtos.Id)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object);
            // Act
            var result = await _usersApiController.Get(userResponseDtos.Id);
            // Assert
            var okResultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.NotNull(result);
            Assert.Equal(userResponseDtos, okResultValue);
        }

        [Fact]
        public async Task GetUser_ById_BadRequest()
        {
            var userResponseDtos = new UserResponseDto
            {
                Id = "1",
                Email = "test.email1@test.com",
                FullName = "Test 1",
                UserName = "User Name 1"
            };
            _userServiceMock.Setup(c => c.GetByIdAsync(userResponseDtos.Id)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object);
            // Act
            var result = await _usersApiController.Get(string.Empty);
            // Assert
            var okResulStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.BadRequest, okResulStatusCode);
        }

    }
}
