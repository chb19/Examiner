using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.DAL.Entities;

namespace Examiner.BLL.Interfaces
{
    public interface ITestService
    {
        Task AddQuestion(QuestionDTO questionDTO, Guid testId);
        Task EditQuestion(QuestionDTO questionDTO);
        Task DeleteQuestion(Guid questionId);

    }
}
