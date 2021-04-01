using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Group : AbstractEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public Guid TestId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Group()
        {
            Students = new List<Student>();
            Tests = new List<Test>();
        }
    }
}
