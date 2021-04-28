using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.BLL.Services;
using Examiner.DAL.Entities;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Examiner.WEB.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private UserManager<User> _userManager;
        public TeacherController(ITeacherService teacherService, UserManager<User> userManager)
        {
            _teacherService = teacherService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            return View("GroupList");
        }

        [HttpGet]
        public async Task<IActionResult> GroupList()
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var groups = await _teacherService.GetAllUserGroups(user.Id);
            List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
            foreach (var group in groups)
            {
                groupViewModels.Add(new GroupViewModel { Title = group.Title });
            }
            return Json(new { data = groupViewModels });
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _teacherService.CreateGroup(new GroupDTO { Title = title, TeacherId = user.Id});
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
