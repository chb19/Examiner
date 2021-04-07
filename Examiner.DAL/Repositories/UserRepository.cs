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
    public class UserRepository : IRepository<User>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<User> _dbSet;

        public UserRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<User>();
        }

        public IEnumerable<User> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void Update(User user)
        {
            _dbSet.Update(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _dbContext.Users.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            User user = _dbSet.Find(id);
            if (user != null)
                _dbSet.Remove(user);
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