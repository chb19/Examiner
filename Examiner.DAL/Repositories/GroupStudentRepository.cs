using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examiner.DAL.EF;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examiner.DAL.Repositories
{
    public class GroupStudentRepository : IRepository<GroupStudent>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<GroupStudent> _dbSet;

        public GroupStudentRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<GroupStudent>();
        }

        public IEnumerable<GroupStudent> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<GroupStudent> Get(Func<GroupStudent, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public GroupStudent Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(GroupStudent GroupStudent)
        {
            _dbContext.GroupStudents.Add(GroupStudent);
        }

        public void Update(GroupStudent GroupStudent)
        {
            _dbSet.Update(GroupStudent);
        }

        public IEnumerable<GroupStudent> Find(Func<GroupStudent, bool> predicate)
        {
            return _dbContext.GroupStudents.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            GroupStudent GroupStudent = _dbSet.Find(id);
            if (GroupStudent != null)
                _dbSet.Remove(GroupStudent);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<GroupStudent> GetAll()
        {
            return _dbContext.GroupStudents;
        }
    }
}
