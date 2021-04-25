using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.DAL.Entities
{
    public class Student : User
    {
        [Required]
        [MaxLength(30)]
        [StringLength(255)]
        public string GradeBook { get; set; }
        public List<GroupStudent> GroupStudents { get; set; }
        public List<AnswerStudent> AnswerStudents { get; set; }
        public List<TestResult> TestResults { get; set; }
        public Guid GroupId { get; set; }
        public Student()
        {
            GroupStudents = new List<GroupStudent>();
            AnswerStudents = new List<AnswerStudent>();
            TestResults = new List<TestResult>(); 
        }
    }
}
