using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Archive : AbstractEntity
    {
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public Guid AnswerId { get; set; }
        public Guid StudentId { get; set; }
        public Archive()
        {
            Answers = new List<Answer>();
            Students = new List<Student>();
        }
    }
}
