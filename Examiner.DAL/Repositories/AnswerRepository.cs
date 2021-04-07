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
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<Answer> _dbSet;

        public AnswerRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Answer>();
        }

        public IEnumerable<Answer> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Answer> Get(Func<Answer, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Answer> GetAll()
        {
            return _dbContext.Answers;
        }

        public Answer Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Answer Answer)
        {
            _dbContext.Answers.Add(Answer);
        }

        public void Update(Answer Answer)
        {
            _dbSet.Update(Answer);
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return _dbContext.Answers.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Answer Answer = _dbSet.Find(id);
            if (Answer != null)
                _dbSet.Remove(Answer);
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