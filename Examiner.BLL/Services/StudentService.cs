using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.BLL.Interfaces;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Examiner.BLL.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _repository;
        private UserManager<User> _userManager;
        public StudentService(IUnitOfWork repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task<IEnumerable<Group>> GetAllStudentGroups(Guid studentId)
        {
            return await Task.Run(() =>
            {
                var groupStudents = _repository.GroupStudents.GetAll().Where(x => x.StudentId == studentId).ToList();
                List<Group> groups = new List<Group>();
                foreach (var grs in groupStudents)
                {
                    var g = _repository.Groups.Find(x => x.Id == grs.GroupId).First();
                    if (!groups.Contains(g))
                    {
                        groups.Add(g);
                    }
                }
                return groups;
            }
            );
        }

    }
}
