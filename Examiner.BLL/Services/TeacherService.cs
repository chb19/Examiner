using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using NLayerApp.DAL.Repositories;

namespace Examiner.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        EFUnitOfWork _repository;
        public async Task AddStudentToGroup(Guid studentId, Guid GroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> CreateGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<Test> CreateTest(Test test)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTest(Guid testId)
        {
            throw new NotImplementedException();
        }

        public async Task<Test> EditTest(Guid testId, Test newTest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Test>> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public async Task<Test> GetSpecificTest(Guid testId)
        {
            throw new NotImplementedException();
        }
    }
}
