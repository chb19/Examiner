using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class TestResult : AbstractEntity
    {
        public int Grade { get; set; }
        public Guid StudentId { get; set; }
        public Guid TestId { get; set; }

        public Test Test { get; set; }
        public Student Student { get; set; }
    }
}
