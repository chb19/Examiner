using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Entities
{
    public class Group : AbstractEntity
    {
        public string? Title { get; set; }
        public List<GroupStudent> GroupStudents { get; set; }
        public List<GroupTest> GroupTests { get; set; }
        public Guid? TestId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Group()
        {
            GroupStudents = new List<GroupStudent>();
            GroupTests = new List<GroupTest>();
        }
    }
}
