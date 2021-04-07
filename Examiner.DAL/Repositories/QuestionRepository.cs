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
    public class QuestionRepository : IRepository<Question>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<Question> _dbSet;

        public QuestionRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Question>();
        }

        public IEnumerable<Question> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Question> Get(Func<Question, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions;
        }

        public Question Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Question Question)
        {
            _dbContext.Questions.Add(Question);
        }

        public void Update(Question Question)
        {
            _dbSet.Update(Question);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return _dbContext.Questions.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Question Question = _dbSet.Find(id);
            if (Question != null)
                _dbSet.Remove(Question);
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