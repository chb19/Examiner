using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Entities
{
    public class Test : AbstractEntity
    {
        public List<Question> Questions { get; set; }
        public List<TestResult> TestResults { get; set; }
        public List<GroupTest> GroupTests { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
        public string Title { get; set; }
        public Test()
        {
            Questions = new List<Question>();
            TestResults = new List<TestResult>();
            GroupTests = new List<GroupTest>();
        }
    }
}
