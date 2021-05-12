using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.BLL.Services;
using Examiner.DAL.Entities;
using Examiner.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Examiner.WEB.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private ITestService _testService;
        private UserManager<User> _userManager;
        public TeacherController(ITeacherService teacherService, UserManager<User> userManager, ITestService testService)
        {
            _teacherService = teacherService;
            _testService = testService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View("GroupList");
        }

        [HttpGet]
        public async Task<IActionResult> GroupList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var groups = await _teacherService.GetAllUserGroups(user.Id);
            List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
            foreach (var group in groups)
            {
                groupViewModels.Add(new GroupViewModel { Title = group.Title, Id = group.Id });
            }
            return Json(new { data = groupViewModels });
        }
        public IActionResult CreateTest() => View();
        [HttpPost]
        public async Task<IActionResult> CreateTest(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _teacherService.CreateTest(new TestDTO { TeacherId = user.Id, Title = title });
                return RedirectToAction("Tests");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> TestList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var tests = await _teacherService.GetAllUserTests(user.Id);
            List<TestViewModel> testViewModels = new List<TestViewModel>();
            foreach (var test in tests)
            {
                testViewModels.Add(new TestViewModel { Title = test.Title, Id = test.Id });
            }
            return Json(new { data = testViewModels });
        }

        public IActionResult Tests()
        {
            return View("TestList");
        }

        [HttpGet]
        public async Task<IActionResult> EditTest(Guid testId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var test = await _teacherService.GetSpecificTest(testId);
            if (test != null && user.Id != test.TeacherId)
            {
                return View("AccessDenied");
            }

            if (test != null)
            {
                TestViewModel testViewModel = new TestViewModel
                {
                    Id = test.Id,
                    Title = test.Title
                };
                return View(testViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditTest(Guid testId, string title)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var test = await _teacherService.GetSpecificTest(testId);
            if (test != null && user.Id != test.TeacherId)
            {
                return View("AccessDenied");
            }
            await _teacherService.EditTest(testId, title);
            return RedirectToAction("Tests");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTest(Guid testId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var test = await _teacherService.GetSpecificTest(testId);
            if (user.Id != test.TeacherId)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            await _teacherService.DeleteTest(testId);
            return Json(new { success = true, message = "Delete successful." });
        }

        [HttpGet]
        public async Task<IActionResult> TestQuestions(Guid testId)
        {
            var questions = await _teacherService.GetAllTestQuestions(testId);
            var test = await _teacherService.GetSpecificTest(testId);
            List<QuestionViewModel> questionViewModels = new List<QuestionViewModel>();
            foreach (var question in questions)
            {
                string answersTxt = string.Empty;
                var answers = await _teacherService.GetQuestionAnswer(question.Id);
                for (int i = 0; i < answers.Count; ++i)
                {
                    if (answers[i].Correctness)
                        answersTxt += "<b>" + answers[i].AnswerText + "</b>";
                    else
                        answersTxt += answers[i].AnswerText;

                    if (i == answers.Count - 1)
                        answersTxt += ".";
                    else
                        answersTxt += ", ";
                }

                questionViewModels.Add(new QuestionViewModel {Id = question.Id, QuestionText = question.QuestionText, AnswerText = answersTxt});
            }
            ViewData["questions"] = JsonConvert.SerializeObject(questionViewModels);
            return View("Test", new TestViewModel { Id = testId, Title = test.Title});
        }

        [HttpGet]
        public IActionResult AddQuestionToTest(Guid testId)
        {
            return View("AddQuestionToTest", testId);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupStudentsList(Guid groupId)
        {
            var students = await _teacherService.GetStudentsFromGroup(groupId);
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var student in students)
            {
                userViewModels.Add(new UserViewModel { FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, Id = student.Id });
            }
            ViewData["students"] = JsonConvert.SerializeObject(userViewModels);
            return View("GroupStudentsList", new GroupViewModel { Id = groupId });
        }

        [HttpPost]
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
        public async Task<IActionResult> EditGroup(Guid groupId)
        {
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
        public async Task<IActionResult> EditGroup(Guid groupId, string title)
        {
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
