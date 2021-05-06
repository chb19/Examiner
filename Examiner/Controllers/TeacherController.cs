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
using Newtonsoft.Json;

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
                groupViewModels.Add(new GroupViewModel { Title = group.Title, Id = group.Id });
            }
            return Json(new { data = groupViewModels });
        }
        public async Task<IActionResult> GetGroupStudentsList(Guid groupId)
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var students = await _teacherService.GetStudentsFromGroup(groupId);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var student in students)
            {
                userViewModels.Add(new UserViewModel { FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, Id = student.Id });
            }
            ViewData["students"] = JsonConvert.SerializeObject(userViewModels).ToString();
            return View("GroupStudentsList", new GroupViewModel { Id = groupId });
        }
        public IActionResult AddStudentToGroup(Guid groupId)
        {
            return View(new GroupViewModel { Id = groupId});
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentToGroup(string email, Guid groupId)
        {
            var student = await _userManager.FindByEmailAsync(email);
            if (student == null)
            {
                return RedirectToAction("GetGroupStudentsList", new { groupId = $"{groupId}" });
            }
            await _teacherService.AddStudentToGroup(student.Id, groupId);
            return RedirectToAction("GetGroupStudentsList", new {groupId=$"{groupId}"});
        }

        public IActionResult CreateGroup() => View();
        [HttpPost]
        public async Task<IActionResult> CreateGroup(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _teacherService.CreateGroup(new GroupDTO { Title = title, TeacherId = user.Id});
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid groupId)
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var group = await _teacherService.GetSpecificGroup(groupId);
            if (group != null && user.Id != group.TeacherId)
            {
                return View("AccessDenied");
            }            

            if (group != null)
            {
                GroupViewModel groupViewModel = new GroupViewModel
                {
                    Id = group.Id,
                    Title = group.Title
                };
                return View(groupViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid groupId, string title)
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var group = await _teacherService.GetSpecificGroup(groupId);
            if (group != null && user.Id != group.TeacherId)
            {
                return View("AccessDenied");
            }
            await _teacherService.EditGroup(groupId, title);
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(Guid groupId)
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var group = await _teacherService.GetSpecificGroup(groupId);
            if (user.Id != group.TeacherId)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            await _teacherService.DeleteGroup(groupId);
            return Json(new { success = true, message = "Delete successful." });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudentFromGroup(Guid groupId, Guid studentId)
        {
            if (!User.IsInRole("Teacher"))
            {
                return View("AccessDenied");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var group = await _teacherService.GetSpecificGroup(groupId);
            if (user.Id != group.TeacherId)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            await _teacherService.DeleteStudentFromGroup(studentId, groupId);
            return Json(new { success = true, message = "Delete successful." });
        }
    }
}
