using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.WEB.ViewModels
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string Answer1 { get; set; }
        public bool Correctness1 { get; set; }
        public string Answer2 { get; set; }
        public bool Correctness2 { get; set; }
        public string Answer3 { get; set; }
        public bool Correctness3 { get; set; }
        public string Answer4 { get; set; }
        public bool Correctness4 { get; set; }
        //public List<AnswerViewModel> Answers { get; set; }

    }
}
