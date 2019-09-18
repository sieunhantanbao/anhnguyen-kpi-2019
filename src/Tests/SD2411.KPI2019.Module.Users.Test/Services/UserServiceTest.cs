using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using SD2411.KPI2019.Module.Core.Data;
using SD2411.KPI2019.Module.Core.Model;
using SD2411.KPI2019.Module.Users.Model;
using SD2411.KPI2019.Module.Users.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SD2411.KPI2019.Module.Users.Test.Services
{
    public class UserServiceTest
    {
        private Mock<DbContextOptions<SD2411DBContext>> _dbContextOptionMock;
        private SD2411DBContext _context;
        private UserService _userService;
        public UserServiceTest()
        {
            _dbContextOptionMock = new Mock<DbContextOptions<SD2411DBContext>>();
            _context = new SD2411DBContext(_dbContextOptionMock.Object);
        }

       // [Fact]
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
            var appUser = new ApplicationUser
            {
                Email = userRequestDtos.Email,
                FullName = userRequestDtos.FullName,
                PhoneNumber = userRequestDtos.PhoneNumber,
                UserName = userRequestDtos.UserName
            };
            var userManagerMock = MockUserManager(new List<ApplicationUser> { appUser });
            _userService = new UserService(userManagerMock.Object, _context);

            // Act
            var result = await _userService.CreateAsync(userRequestDtos);
            // Assert
            Assert.Equal(userResponseDtos, result);
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }
    }
}
