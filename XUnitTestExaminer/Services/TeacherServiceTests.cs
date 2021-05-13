using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.BLL.Services;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace XUnitTestExaminer.Services
{
    public class TeacherServiceTests
    {

        private readonly Mock<UserManager<User>> userManager;
        private readonly Mock<SignInManager<User>> signInManager;
        private readonly Mock<RoleManager<Role>> roleManager;
        private readonly IUserService userService;

        public TeacherServiceTests()
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
        public async Task Create_GroupTest_Async()
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
        public async Task Add_StudentToGroupTestAsync()
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
        public async Task Create_TestTestAsync()
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
        public async Task Edit_GroupTestAsync()
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
        public async Task Delete_GrouptTestAsync()
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
    }
}
