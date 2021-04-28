﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Examiner.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}

