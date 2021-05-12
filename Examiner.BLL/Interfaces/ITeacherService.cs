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
        Task<IEnumerable<Question>> GetAllTestQuestions(Guid testId);
        Task<Test> GetSpecificTest(Guid testId);
        Task<Group> GetSpecificGroup(Guid groupId);
        Task CreateTest(TestDTO testDto);
        Task DeleteTest(Guid testId);
        Task DeleteGroup(Guid groupId);
        Task EditTest(Guid testId, string newTitle);
        Task EditGroup(Guid groupId, string newTitle);
        Task AddStudentToGroup(Guid studentId, Guid GroupId);
        Task CreateGroup(GroupDTO groupDto);
        Task<IEnumerable<Student>> GetStudentsFromGroup(Guid groupId);
        Task<List<User>> GetAllStudents();
        Task<List<Answer>> GetQuestionAnswer(Guid questionId);
        Task DeleteStudentFromGroup(Guid studentId, Guid groupId);

    }
}
