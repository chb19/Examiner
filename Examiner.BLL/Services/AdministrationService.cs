using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Services
{
    public class AdministrationService : IAdministrationService
    {
        UserManager<User> _userManager;
        public AdministrationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return await Task.Run(() => _userManager.DeleteAsync(user));
        }

        public async Task<IdentityResult> EditUserPassword(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return await Task.Run(() => _userManager.ChangePasswordAsync(user, currentPassword, newPassword));
        }

        public async Task<IdentityResult> EditUserRole(Guid userId, List<string> Roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            user.Role = Roles[0];
            return await Task.Run(() =>
            {
                return _userManager.AddToRolesAsync(user, Roles);
            });
        }
        
        public async Task<List<User>> GetAllUsers()
        {
            return await Task.Run(() => _userManager.Users.ToList());
        }
        public async Task<List<string>> GetUserRoles(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return await Task.Run(() => _userManager.GetRolesAsync(user).Result.ToList());
        }
        public async Task<User> GetUserById(Guid userId)
        {
            return await Task.Run(() => _userManager.FindByIdAsync(userId.ToString()));
        }
    }
}
