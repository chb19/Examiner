using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.BLL.DTO;
using Examiner.WEB.ViewModels;
using Examiner.BLL.Services;

namespace Examiner.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private ILoggerService _loggerService;
        public AccountController(IUserService userService, ILoggerService loggerService)
        {
            _userService = userService;
            _loggerService = loggerService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError(string.Empty, "Passwords doesn't match");
            }
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(new UserDTO { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Password = model.Password } );
                if (result.Succeeded)
                {
                    var resultOfLogIn = await _userService.Authenticate(new UserDTO { Email = model.Email, Password = model.Password });
                    if (resultOfLogIn.Succeeded)
                    {
                        _loggerService.LogInfo($"User {model.Email} registered.");
                        return RedirectToAction("Index", "Home");
                    }    
                }
                _loggerService.LogError($"Failed {model} to register.");
                ModelState.AddModelError(string.Empty, "Invalid login or password");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Authenticate(new UserDTO { Email = model.Email, Password = model.Password });
                if (result.Succeeded)
                {
                    _loggerService.LogInfo($"User {model.Email} logged in.");
                    return RedirectToAction("Index", "Home");
                }
                _loggerService.LogError($"User {model} failed to log in.");
                ModelState.AddModelError(string.Empty, "Invalid login or password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _userService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
