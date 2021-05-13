using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.WEB.Controllers;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace XUnitTestExaminer.Controllers
{
    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<ILoggerService> _loggerService;

        public AccountControllerTests()
        {
            _userService = new Mock<IUserService>();
            _loggerService = new Mock<ILoggerService>();
            _accountController = new AccountController(_userService.Object, _loggerService.Object);
        }
        [Fact]
        public async Task LoginPost_SignInNotSucceeded_TestAsync()
        {
            _userService.Setup(x => x.Authenticate(It.IsAny<UserDTO>())).ReturnsAsync(new Microsoft.AspNetCore.Identity.SignInResult());

            var result = await _accountController.Login(new LoginViewModel());

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task LoginPost_InvalidModelState_TestAsync()
        {
            _userService.Setup(x => x.Authenticate(It.IsAny<UserDTO>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
            _accountController.ModelState.AddModelError(string.Empty, "error");
            var result = await _accountController.Login(new LoginViewModel());

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task LoginPost_SignInSucceeded_TestAsync()
        {
            _userService.Setup(x => x.Authenticate(It.IsAny<UserDTO>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var result = await _accountController.Login(new LoginViewModel());

            Assert.NotNull(result);
        }

    }
}
