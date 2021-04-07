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
    public class TestResultRepository : IRepository<TestResult>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<TestResult> _dbSet;

        public TestResultRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<TestResult>();
        }

        public IEnumerable<TestResult> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TestResult> Get(Func<TestResult, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TestResult> GetAll()
        {
            return _dbContext.TestResults;
        }

        public TestResult Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(TestResult TestResult)
        {
            _dbContext.TestResults.Add(TestResult);
        }

        public void Update(TestResult TestResult)
        {
            _dbSet.Update(TestResult);
        }

        public IEnumerable<TestResult> Find(Func<TestResult, bool> predicate)
        {
            return _dbContext.TestResults.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            TestResult TestResult = _dbSet.Find(id);
            if (TestResult != null)
                _dbSet.Remove(TestResult);
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