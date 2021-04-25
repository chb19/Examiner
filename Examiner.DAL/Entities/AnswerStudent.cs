using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Abstractions;

namespace Examiner.DAL.Entities
{
    public class AnswerStudent : AbstractEntity
    {
        public Guid AnswerId { get; set; }
        public Guid StudentId { get; set; }
        public Answer Answer { get; set; }
        public Student Student { get; set; }

    }
}
