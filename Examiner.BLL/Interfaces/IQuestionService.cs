using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;

namespace Examiner.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> EditQuestionText(Guid questionId, string newQuestionText);
        Task<Question> EditQuestionAnswer(Guid questionId, Answer newQuestionAnswer);
    }
}
