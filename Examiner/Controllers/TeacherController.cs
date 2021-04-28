using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.Services;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Examiner.WEB.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherService _teacherService;
        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
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
            var groups = await _teacherService.GetAllGroups();
            List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
            foreach (var group in groups)
            {
                groupViewModels.Add(new GroupViewModel { Title = group.Title });
            }
            return Json(new { data = groupViewModels });
        }

    }
}
