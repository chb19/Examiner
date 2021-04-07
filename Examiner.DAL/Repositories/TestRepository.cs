using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examiner.DAL.EF;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examiner.DAL.Repositories
{
    public class TestRepository : IRepository<Test>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<Test> _dbSet;

        public TestRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Test>();
        }

        public IEnumerable<Test> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Test> Get(Func<Test, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Test> GetAll()
        {
            return _dbContext.Tests;
        }

        public Test Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Test Test)
        {
            _dbContext.Tests.Add(Test);
        }

        public void Update(Test Test)
        {
            _dbSet.Update(Test);
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            return _dbContext.Tests.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Test Test = _dbSet.Find(id);
            if (Test != null)
                _dbSet.Remove(Test);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}