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
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork _repository;
        private UserManager<User> _userManager;
        public TeacherService(IUnitOfWork repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task CreateGroup(GroupDTO groupDto)
        {
            await Task.Run(() =>
            {
                _repository.Groups.Create(new Group { Title = groupDto.Title, TeacherId = groupDto.TeacherId });
                _repository.Save();
            });
        }

        public async Task CreateTest(TestDTO testDto)
        {
            await Task.Run(() =>
            {
                _repository.Tests.Create(new Test { Title = testDto.Title, TeacherId = testDto.TeacherId });
                _repository.Save();
            });
        }

        public async Task DeleteTest(Guid testId)
        {
            await Task.Run(() =>
            {
                _repository.Tests.Delete(testId);
                _repository.Save();
            });

        }

        public async Task EditTest(Guid testId, string newTitle)
        {
            var test = _repository.Tests.Find(x => x.Id == testId).First();
            test.Title = newTitle;
            await Task.Run(() => 
            { 
                _repository.Tests.Update(test);
                _repository.Save();
            });
        }
        public async Task<IEnumerable<Test>> GetAllUserTests(Guid userId)
        {
            return await Task.Run(() =>
            {
                return _repository.Tests.GetAll().Where(x => x.TeacherId == userId).ToList();
            }
            ); 
        }
        public async Task<IEnumerable<Group>> GetAllUserGroups(Guid userId)
        {
            return await Task.Run(() =>
            {
                return _repository.Groups.GetAll().Where(x => x.TeacherId == userId).ToList();
            }
            ); 
        }
        public async Task<List<User>> GetAllStudents()
        {
            return await Task.Run(() =>
            {
               return _userManager.Users.Where(x => x.Role == "Student").ToList();
            }
            ); 
        }

        public async Task<Test> GetSpecificTest(Guid testId)
        {
            return await Task.Run(() =>
            {
                return _repository.Tests.Find(x => x.Id == testId).First();
            }
            );
        }

        public async Task AddStudentToGroup(Guid studentId, Guid groupId)
        {
            var sg = _repository.GroupStudents.Find(x => x.GroupId == groupId && x.StudentId == studentId).ToList();
            if (sg.Count > 0)
            {
                return;
            }

            var student = await _userManager.FindByIdAsync(studentId.ToString());
            var stud = (Student)student;
            if (stud != null)
            {
                await Task.Run(() =>
                {
                    _repository.GroupStudents.Create(new GroupStudent { GroupId = groupId, StudentId = studentId, Student = stud });
                    _repository.Save();
                });
            }
        }        
        public async Task DeleteStudentFromGroup(Guid studentId, Guid groupId)
        {
            var sg = _repository.GroupStudents.Find(x => x.GroupId == groupId && x.StudentId == studentId).ToList();
            if (sg.Count == 0)
            {
                return;
            }

            var student = await _userManager.FindByIdAsync(studentId.ToString());
            if (student.Role != "Student")
            {
                return;
            }
            var stud = (Student)student;
            if (stud != null)
            {
                await Task.Run(() =>
                {
                    _repository.GroupStudents.Delete(sg[0].Id);
                    _repository.Save();
                });
            }
        }

        public async Task<Group> GetSpecificGroup(Guid groupId)
        {
            return await Task.Run(() =>
            {
                return _repository.Groups.Find(x => x.Id == groupId).First();
            }
            );
        }

        public async Task DeleteGroup(Guid groupId)
        {
            await Task.Run(() =>
            {
                _repository.Groups.Delete(groupId);
                _repository.Save();
            });
        }

        public async Task EditGroup(Guid groupId, string newTitle)
        {
            var group = _repository.Groups.Find(x => x.Id == groupId).First();
            group.Title = newTitle;
            await Task.Run(() =>
            {
                _repository.Groups.Update(group);
                _repository.Save();
            });
        }

        public async Task<IEnumerable<Student>> GetStudentsFromGroup(Guid groupId)
        {
            List<Student> students = new List<Student>();
            var studentsId = _repository.GroupStudents.GetAll().Where(x => x.GroupId == groupId).Select(x=> x.StudentId);
            var s = _userManager.Users.Where(x => x.Role == "Student").ToList();
            foreach (var stud in s)
            {
                if (studentsId.Contains(stud.Id))
                {
                    students.Add((Student)stud);
                }
            }
            return await Task.Run(() =>
            {
                return students;
            });

    }
}
