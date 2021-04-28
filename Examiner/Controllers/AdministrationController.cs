using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examiner.WEB.Controllers
{
    public class AdministrationController : Controller
    {
        private IAdministrationService _administrationService;
        private ILoggerService _loggerService;
        private List<SelectListItem> roles;

        public AdministrationController(IAdministrationService administrationService, ILoggerService loggerService)
        {
            _administrationService = administrationService;
            _loggerService = loggerService;
            roles = new List<SelectListItem>();
            roles.Add(new SelectListItem() { Value = "Admin", Text = "Admin" });
            roles.Add(new SelectListItem() { Value = "Teacher", Text = "Teacher" });
            roles.Add(new SelectListItem() { Value = "Student", Text = "Student" });
        }
        public IActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return View("AccessDenied");
            }
            return View("UserList");
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            if (!User.IsInRole("Admin"))
            {
                return View("AccessDenied");
            }
            var users = await _administrationService.GetAllUsers();
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                if (user.Email == User.Identity.Name)
                {
                    continue;
                }
                userViewModels.Add(new UserViewModel { Email = user.Email, FirstName = user.FirstName, Id = user.Id, LastName = user.LastName, Role = _administrationService.GetUserRoles(user.Id).Result.First() });
            }
            return Json(new { data = userViewModels });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid userId, string role)
        {
            if (!User.IsInRole("Admin"))
            {
                return View("AccessDenied");
            }
            List<string> roles = new List<string> { role };
            var user = await _administrationService.GetUserById(userId);
            await _administrationService.EditUserRole(userId, roles);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid userId)
        {
            if (!User.IsInRole("Admin"))
            {
                return View("AccessDenied");
            }
            ViewBag.Roles = roles;
            var user = await _administrationService.GetUserById(userId);
            if (user != null)
            {
                var role = await _administrationService.GetUserRoles(userId);
                UserViewModel userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = role.First()
                };
                return View(userViewModel);
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId)
        {
            if (!User.IsInRole("Admin"))
            {
                return View("AccessDenied");
            }
            var user = await _administrationService.GetUserById(userId);
            if (user == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            await _administrationService.DeleteUser(userId);
            return Json(new { success = true, message = "Delete successful." });
        }
    }
}
