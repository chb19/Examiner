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
    public class GroupTestRepository : IRepository<GroupTest>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<GroupTest> _dbSet;

        public GroupTestRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<GroupTest>();
        }

        public IEnumerable<GroupTest> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<GroupTest> Get(Func<GroupTest, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public GroupTest Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(GroupTest GroupTest)
        {
            _dbContext.GroupTests.Add(GroupTest);
        }

        public void Update(GroupTest GroupTest)
        {
            _dbSet.Update(GroupTest);
        }

        public IEnumerable<GroupTest> Find(Func<GroupTest, bool> predicate)
        {
            return _dbContext.GroupTests.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            GroupTest GroupTest = _dbSet.Find(id);
            if (GroupTest != null)
                _dbSet.Remove(GroupTest);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<GroupTest> GetAll()
        {
            return _dbContext.GroupTests;
        }
    }
}
