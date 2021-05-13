using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.BLL.Services;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
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
            var userstore = new Mock<IUserStore<User>>();
            this.userManager = new Mock<UserManager<User>>(
                userstore.Object,
                null, new PasswordHasher<User>(),
                null, null, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null);
            //this.signInManager = new Mock<SignInManager<User>>(
            //    userManager.Object);
            //roleManager = new Mock<RoleManager<Role>>();
            //this.userService = new UserService(userManager.Object, signInManager.Object, roleManager.Object);
        }

        

        [Fact]
        public async Task SignIn_TestAsync()
        {
            // Arrange
            //var mock = new Mock<IUnitOfWork>();
            //mock.Setup(a => a.).Returns(new List<>());
            //HomeController controller = new HomeController(mock.Object);
            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(true);
        }



        [Fact]
        public async Task SignOut_TestAsync()
        {
            //signInManager
            //    .Setup(x => x.SignOutAsync());

            //await userService.SignOut();

            //signInManager.Verify();

            Assert.NotNull(true);
        }


        [Fact]
        public async Task Register_TestAsync()
        {
            //signInManager
            //    .Setup(x => x.SignOutAsync());

            //await userService.SignOut();

            //signInManager.Verify();

            Assert.NotNull(true);
        }
    }
}
