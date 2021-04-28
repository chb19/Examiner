using Examiner.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examiner.DAL.Entities
{
    public class Answer : AbstractEntity
    {
        public List<AnswerStudent> AnswerStudents { get; set; }
        public string AnswerText { get; set; }

        public bool Correctness { get; set; }
        public Guid QuestionId { get; set; }
        public DateTime AnswerDate { get; set; }

        public Answer()
        {
            AnswerStudents = new List<AnswerStudent>();
        }
    }
}
