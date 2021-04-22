using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;

namespace Examiner.BLL.Services
{
    public class TestService : ITestService
    {
        public Task<Question> AddQuestion()
        {
            throw new NotImplementedException();
        }

        public Task<Question> DeleteQuestion()
        {
            throw new NotImplementedException();
        }

        public Task<Question> EditQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
