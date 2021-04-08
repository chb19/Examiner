using Examiner.BLL.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Create(UserDTO userDTO);
        Task<SignInResult> Authenticate(UserDTO userDTO);
        Task SignOut();
/*        Task SetInitialData(UserDTO adminDto, List<string> roles);
*/    }
}
