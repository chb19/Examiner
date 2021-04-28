using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Interfaces
{
    public interface IAdministrationService
    {
        Task<IdentityResult> EditUserRole(Guid userId, List<string> Roles);
        Task<IdentityResult> DeleteUser(Guid userId);
        Task<IdentityResult> EditUserPassword(Guid userId, string currentPassword, string newPassword);
        Task<List<User>> GetAllUsers();
        Task<List<string>> GetUserRoles(Guid userId);
        Task<User> GetUserById(Guid Id);
    }
}
