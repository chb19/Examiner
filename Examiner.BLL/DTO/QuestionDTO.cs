using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;

namespace Examiner.BLL.DTO
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public Answer Answer { get; set; }
    }
}
