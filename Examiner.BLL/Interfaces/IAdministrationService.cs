using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Interfaces
{
    public interface IAdministrationService
    {
        Task<IdentityResult> EditUserRole(User user, List<string> Roles);
        Task<IdentityResult> DeleteUser(User user);
        Task<IdentityResult> EditUserPassword(User user, string currentPassword, string newPassword);
        Task<List<User>> GetAllUsers();
    }
}
