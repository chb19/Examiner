using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<SignInResult> Authenticate(UserDTO userDTO)
        {
            var user = _userManager.FindByEmailAsync(userDTO.Email).Result;
            if (user == null)
            {
                return SignInResult.NotAllowed;
            }
            var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, true, false);
            return result;
        }

        public async Task<IdentityResult> Create(UserDTO userDTO)
        {
            User user = new User { Email = userDTO.Email, UserName = userDTO.Email, FirstName = userDTO.FirstName, LastName = userDTO.LastName };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, "Student");
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return result;
                }
            }
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
