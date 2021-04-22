using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;

namespace Examiner.BLL.Interfaces
{
    public interface ITestService
    {
        Task<Question> AddQuestion();
        Task<Question> EditQuestion();
        Task<Question> DeleteQuestion();

    }
}
