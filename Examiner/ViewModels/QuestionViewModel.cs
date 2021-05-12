using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.WEB.ViewModels
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerViewModel> Answers { get; set; }

    }
}
