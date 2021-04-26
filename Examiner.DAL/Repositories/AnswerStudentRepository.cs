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
    public class AnswerStudentRepository : IRepository<AnswerStudent>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<AnswerStudent> _dbSet;

        public AnswerStudentRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<AnswerStudent>();
        }

        public IEnumerable<AnswerStudent> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<AnswerStudent> Get(Func<AnswerStudent, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public AnswerStudent Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(AnswerStudent AnswerStudent)
        {
            _dbContext.AnswerStudents.Add(AnswerStudent);
        }

        public void Update(AnswerStudent AnswerStudent)
        {
            _dbSet.Update(AnswerStudent);
        }

        public IEnumerable<AnswerStudent> Find(Func<AnswerStudent, bool> predicate)
        {
            return _dbContext.AnswerStudents.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            AnswerStudent AnswerStudent = _dbSet.Find(id);
            if (AnswerStudent != null)
                _dbSet.Remove(AnswerStudent);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<AnswerStudent> GetAll()
        {
            return _dbContext.AnswerStudents;
        }
    }
}
