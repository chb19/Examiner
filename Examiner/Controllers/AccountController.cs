using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.BLL.DTO;

namespace Examiner.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(model);
                if (result.Succeeded)
                {
                    var resultOfLogIn = await _userService.Authenticate(new UserDTO { Email = model.Email, Password = model.Password });
                    if (resultOfLogIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }    
                }
                ModelState.AddModelError("", "Invalid login or password");
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
        public async Task<IActionResult> Login(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Authenticate(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);
        }
    }
}
