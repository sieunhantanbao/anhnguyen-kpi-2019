using Microsoft.AspNetCore.Http;
using Moq;
using SD2411.KPI2019.Infrastructure.Model;
using SD2411.KPI2019.Module.Users.Controllers;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Users.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace SD2411.KPI2019.Module.Users.Test.Controllers
{
    public class UserApiControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private UsersApiController _usersApiController;
        public UserApiControllerTest()
        {
            this._userServiceMock = new Mock<IUserService>();
            this._httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        }

        [Fact(DisplayName = "GetListUsers_WithPaging_Success")]
        public async Task GetListUsers_WithPaging_Success()
        {
            // Arrange
            var pageIndex = 0;
            var pageSize = 10;
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
            var listUsers = new PaginatedItems<UserResponseDto, string>(pageIndex, pageSize, userResponseDtos.Count, userResponseDtos);
            _userServiceMock.Setup(c => c.ListAsync(pageIndex, pageSize)).ReturnsAsync(listUsers);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get(0, 10);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.NotNull(result);
            Assert.Equal(listUsers, resultValue);
        }

        [Fact(DisplayName = "GetUser_ById_Success")]
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
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get(userResponseDtos.Id);
            // Assert
            var resultValue = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.NotNull(result);
            Assert.Equal(userResponseDtos, resultValue);
        }

        [Fact(DisplayName = "GetUser_ById_BadRequest")]
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
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get(string.Empty);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.BadRequest, resultStatusCode);
        }

        [Fact(DisplayName = "GetUser_ById_NoContent")]
        public async Task GetUser_ById_NoContent()
        {
            var userId = Guid.NewGuid().ToString();
            _userServiceMock.Setup(c => c.GetByIdAsync(userId)).ReturnsAsync((UserResponseDto)null);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get(userId);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatusCode);
        }

        [Fact(DisplayName = "CreateUser_ValidUser_Success")]
        public async Task CreateUser_ValidUser_Success()
        {
            // Arrange
            var userRequestDtos = new UserRequestDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest",
                Password = "SecurePasswordCannotShare"
            };
            var userResponseDtos = new UserResponseDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest"
            };
            _userServiceMock.Setup(c => c.CreateAsync(userRequestDtos)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Post(userRequestDtos);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            var resultValue = (UserResponseDto)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Created, resultStatusCode);
            Assert.Equal(userRequestDtos.Email, resultValue.Email);
        }

        [Fact(DisplayName = "UpdateUser_ValidUser_Success")]
        public async Task UpdateUser_ValidUser_Success()
        {
            // Arrange
            var userRequestDtos = new UserRequestDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest",
                Password = "SecurePasswordCannotShare"
            };
            var userResponseDtos = new UserResponseDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest"
            };
            _userServiceMock.Setup(c => c.UpdateAsync(userRequestDtos.Id, userRequestDtos)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Put(userRequestDtos.Id, userRequestDtos);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode;
            var resultValue = (UserResponseDto)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value;
            Assert.Equal((int)HttpStatusCode.Accepted, resultStatusCode);
            Assert.Equal(userRequestDtos.Email, resultValue.Email);
        }

        [Fact(DisplayName = "DeleteUser_UserId_Success")]
        public async Task DeleteUser_UserId_Success()
        {
            // Arrange
            var userId = "1";
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Delete(userId);
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatusCode);
        }

        [Fact(DisplayName = "GetMyProfile_ValidToken_Success")]
        public async Task GetMyProfile_ValidToken_Success()
        {
            // Arrange
            var userId = "1";
            var userResponseDtos = new UserResponseDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest"
            };
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(type:JwtRegisteredClaimNames.Jti,value:userId),
                new Claim(type:JwtRegisteredClaimNames.Aud,value:"testAud")
            };

            Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
            Mock<ClaimsPrincipal> userMock = new Mock<ClaimsPrincipal>();

            _httpContextAccessorMock.Setup(c => c.HttpContext).Returns(httpContextMock.Object);
            httpContextMock.Setup(c => c.User).Returns(userMock.Object);
            userMock.Setup(c => c.Claims).Returns(claims);

            _userServiceMock.Setup(c => c.GetByIdAsync(userId)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get();
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).StatusCode;
            var resultValue = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;
            Assert.Equal((int)HttpStatusCode.OK, resultStatusCode);
            Assert.Equal(userResponseDtos, resultValue);
        }

        [Fact(DisplayName = "GetMyProfile_ValidToken_NoContent")]
        public async Task GetMyProfile_ValidToken_NoContent()
        {
            // Arrange
            var userId = "1";
            var userResponseDtos = new UserResponseDto
            {
                Id = "1",
                Email = "test.abc@com.vn",
                FullName = "Test Full Name",
                UserName = "usernametest"
            };
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(type:JwtRegisteredClaimNames.Jti,value:"2"),
                new Claim(type:JwtRegisteredClaimNames.Aud,value:"testAud")
            };

            Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
            Mock<ClaimsPrincipal> userMock = new Mock<ClaimsPrincipal>();

            _httpContextAccessorMock.Setup(c => c.HttpContext).Returns(httpContextMock.Object);
            httpContextMock.Setup(c => c.User).Returns(userMock.Object);
            userMock.Setup(c => c.Claims).Returns(claims);

            _userServiceMock.Setup(c => c.GetByIdAsync(userId)).ReturnsAsync(userResponseDtos);
            _usersApiController = new UsersApiController(_userServiceMock.Object, _httpContextAccessorMock.Object);
            // Act
            var result = await _usersApiController.Get();
            // Assert
            var resultStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode;
            Assert.Equal((int)HttpStatusCode.NoContent, resultStatusCode);
        }

    }
}
