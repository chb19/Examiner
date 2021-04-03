using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Entities
{
    public class Archive : AbstractEntity
    {
        public List<AnswerArchive> AnswerArchives { get; set; }
        public List<ArchiveStudent> ArchiveStudents { get; set; }
        public Guid AnswerId { get; set; }
        public Guid StudentId { get; set; }
        public Archive()
        {
            AnswerArchives = new List<AnswerArchive>();
            ArchiveStudents = new List<ArchiveStudent>();
        }
    }
}
