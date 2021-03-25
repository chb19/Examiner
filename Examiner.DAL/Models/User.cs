using System.ComponentModel.DataAnnotations;
using Examiner.DAL.Abstractions;

namespace Examiner.DAL.Models
{
    public class User : AbstractEntity
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

