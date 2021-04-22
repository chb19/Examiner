using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Services
{
    public class AdministrationService : IAdministrationService
    {
        UserManager<User> _userManager;
        public async Task<IdentityResult> DeleteUser(User user)
        {
            return await Task.Run(() => _userManager.DeleteAsync(user)).ConfigureAwait(false);
        }

        public async Task<IdentityResult> EditUserPassword(User user, string currentPassword, string newPassword)
        {
            return await Task.Run(() => _userManager.ChangePasswordAsync(user, currentPassword, newPassword)).ConfigureAwait(false);

        }

        public async Task<IdentityResult> EditUserRole(User user, List<string> Roles)
        {
            return await Task.Run(() =>
            {
                var currentRoles = _userManager.GetRolesAsync(user).Result;
                _userManager.RemoveFromRolesAsync(user, currentRoles);
                return _userManager.AddToRolesAsync(user, Roles);
            }).ConfigureAwait(false);

        }
        public async Task<List<User>> GetAllUsers()
        {
            return await Task.Run(() =>
            {
                return _userManager.Users.ToList();
            }).ConfigureAwait(false);
        }
    }
}
