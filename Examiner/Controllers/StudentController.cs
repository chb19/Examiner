using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Examiner.WEB.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private UserManager<User> _userManager;
        public StudentController(IStudentService studentService, UserManager<User> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (!User.IsInRole("Student"))
            {
                return View("AccessDenied");
            }
            return View("GroupList");
        }

        [HttpGet]
        public async Task<IActionResult> GroupList()
        {
            if (!User.IsInRole("Student"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var groups = await _studentService.GetAllStudentGroups(user.Id);
            List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
            foreach (var group in groups)
            {
                groupViewModels.Add(new GroupViewModel { Title = group.Title, Id = group.Id });
            }
            return Json(new { data = groupViewModels });
        }
    }
}
