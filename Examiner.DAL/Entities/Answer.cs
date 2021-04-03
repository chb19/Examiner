using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examiner.DAL.Entities
{
    public class Answer : AbstractEntity
    {
        public List<AnswerArchive> AnswerArchives { get; set; }
        [Required]
        public string AnswerText { get; set; }

        [Required]
        public bool Correctness { get; set; }
        public Guid ArchiveId { get; set; }
        public Guid QuestionId { get; set; }
        public DateTime AnswerDate { get; set; }

        public Answer()
        {
            AnswerArchives = new List<AnswerArchive>();
        }
    }
}
