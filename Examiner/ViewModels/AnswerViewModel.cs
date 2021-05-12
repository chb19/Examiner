using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examiner.WEB.ViewModels
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string AnswerText { get; set; }
        public bool Correctness { get; set; }
    }
}
