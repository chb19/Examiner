using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.WEB.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestExaminer.TestService
{
    public class UserControllerTest
    {
        [Fact]
        public void LoginViewResultNotNull()
        {
            AccountController controller = new AccountController();
            ViewResult result = controller.Login() as ViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void RegisterViewResultNotNull()
        {
            AccountController controller = new AccountController();
            ViewResult result = controller.Register() as ViewResult;
            Assert.NotNull(result);
        }

    }
}
