using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examiner.DAL.Models
{
    public class Answer : AbstractEntity
    {
        [Required]
        public string AnswerText { get; set; }

        [Required]
        public bool Correctness { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
