using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Role : IdentityRole<Guid>
    {
        public Role() { }
        public Role(string roleName) : base(roleName) { }

    }
}
