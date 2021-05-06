using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.BLL.Services;
using Examiner.DAL.Entities;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace XUnitTestExaminer.Services
{
    public class UserServiceTests
    {
        private readonly Mock<UserManager<User>> userManager;
        private readonly Mock<SignInManager<User>> signInManager;
        private readonly Mock<RoleManager<Role>> roleManager;
        private readonly IUserService userService;
        public UserServiceTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            this.userManager = new Mock<UserManager<User>>(
                userStore.Object,
                null, new PasswordHasher<User>(),
                null, null, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null);
            this.signInManager = new Mock<SignInManager<User>>(
                userManager.Object);
            roleManager = new Mock<RoleManager<Role>>();
            this.userService = new UserService(userManager.Object, signInManager.Object, roleManager.Object);
        }

        [Fact]
        public async Task SignIn_TestAsync()
        {
            userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            var result = await userService.Authenticate(new UserDTO());

            userManager.Verify();
            Assert.NotNull(result);
            Assert.IsType<SignInResult>(result);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task SignOut_TestAsync()
        {
            signInManager
                .Setup(x => x.SignOutAsync());

            await userService.SignOut();

            signInManager.Verify();
        }

    }}
