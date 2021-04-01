using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.DAL.Models
{
    public class Student : User
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string GradeBook { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public Guid GroupId { get; set; }
        public Guid ArchiveId { get; set; }
        public Student()
        {
            Groups = new List<Group>();
            Archives = new List<Archive>();
        }
    }
}
