using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class Teacher : User
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string Department { get; set; }
        public List<Group> Groups { get; set; }
        public List<Test> Tests { get; set; }
        
        public Teacher()
        {
            Groups = new List<Group>();
            Tests = new List<Test>();
        }
    }
}
