using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Answer : AbstractEntity
    {
        public virtual ICollection<Archive> Archives { get; set; }
        [Required]
        public string AnswerText { get; set; }

        [Required]
        public bool Correctness { get; set; }
        public Guid ArchiveId { get; set; }
        public Guid QuestionId { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
