using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examiner.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Test>> GetAllUserTests(Guid userId);
        Task<IEnumerable<Group>> GetAllUserGroups(Guid userId);
        Task<Test> GetSpecificTest(Guid testId);
        Task CreateTest(TestDTO testDto);
        Task DeleteTest(Guid testId);
        Task EditTest(Guid testId, string newTitle);
        Task AddStudentToGroup(Guid studentId, Guid GroupId);
        Task CreateGroup(GroupDTO groupDto);
    }
}
