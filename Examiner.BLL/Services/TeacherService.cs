using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.DTO;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using NLayerApp.DAL.Repositories;

namespace Examiner.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private EFUnitOfWork _repository;
        public TeacherService(EFUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task AddStudentToGroup(Guid studentId, Guid GroupId)
        {

        }

        public async Task CreateGroup(GroupDTO groupDto)
        {
            await Task.Run(() => _repository.Groups.Create(new Group { Title = groupDto.Title } ));
        }

        public async Task CreateTest(TestDTO testDto)
        {
            await Task.Run(() => _repository.Tests.Create(new Test { Title = testDto.Title }));
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
        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await Task.Run(() =>
                _repository.Tests.GetAll()
            ); 
        }
        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await Task.Run(() =>
                _repository.Groups.GetAll()
            ); 
        }

        public async Task<Test> GetSpecificTest(Guid testId)
        {
            return await Task.Run(() =>
                _repository.Tests.Find(x => x.Id == testId).First()
            );
        }
    }
}
