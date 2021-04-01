using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Test : AbstractEntity
    {
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
        public Test()
        {
            Questions = new List<Question>();
            TestResults = new List<TestResult>();
            Groups = new List<Group>();
        }
    }
}
