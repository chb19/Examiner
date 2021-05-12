using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;

namespace Examiner.BLL.DTO
{
    public class TestDTO
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid GroupId { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
