using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Examiner.DAL.Abstractions;

namespace Examiner.DAL.Entities
{
    public class Question : AbstractEntity
    {
        [Required]
        public string QuestionText { get; set; }

        [Required]
        public Answer CorrectAnswer { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}
