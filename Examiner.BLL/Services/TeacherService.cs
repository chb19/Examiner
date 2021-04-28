using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Examiner.DAL.Repositories;

namespace Examiner.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork _repository;
        public TeacherService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task CreateGroup(GroupDTO groupDto)
        {
            await Task.Run(() => _repository.Groups.Create(new Group { Title = groupDto.Title, TeacherId = groupDto.TeacherId } ));
        }

        public async Task CreateTest(TestDTO testDto)
        {
            await Task.Run(() => _repository.Tests.Create(new Test { Title = testDto.Title, TeacherId = testDto.TeacherId }));
        }

        public async Task DeleteTest(Guid testId)
        {
            await Task.Run(() => _repository.Tests.Delete(testId));
        }

        public async Task EditTest(Guid testId, string newTitle)
        {
            var test = _repository.Tests.Find(x => x.Id == testId).First();
            test.Title = newTitle;
            await Task.Run(() => _repository.Tests.Update(test));
        }
        public async Task<IEnumerable<Test>> GetAllUserTests(Guid userId)
        {
            return await Task.Run(() =>
                _repository.Tests.GetAll().Where(x => x.TeacherId == userId).ToList()
            ); 
        }
        public async Task<IEnumerable<Group>> GetAllUserGroups(Guid userId)
        {
            return await Task.Run(() =>
                _repository.Groups.GetAll().Where(x => x.TeacherId == userId).ToList()
            ); 
        }

        public async Task<Test> GetSpecificTest(Guid testId)
        {
            return await Task.Run(() =>
                _repository.Tests.Find(x => x.Id == testId).First()
            );
        }

        public Task AddStudentToGroup(Guid studentId, Guid GroupId)
        {
            throw new NotImplementedException();
        }
    }
}
