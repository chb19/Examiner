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
        public Test()
        {
            Questions = new List<Question>();
            TestResults = new List<TestResult>();
        }
    }
}
