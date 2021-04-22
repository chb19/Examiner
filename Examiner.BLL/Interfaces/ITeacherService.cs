using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examiner.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetSpecificTest(Guid testId);
        Task<Test> CreateTest(Test test);
        Task DeleteTest(Guid testId);
        Task<Test> EditTest(Guid testId, Test newTest);
        Task AddStudentToGroup(Guid studentId, Guid GroupId);
        Task<Group> CreateGroup(Group group);
    }
}
