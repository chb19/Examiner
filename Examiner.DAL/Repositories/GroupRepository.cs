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
    public class GroupRepository : IRepository<Group>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<Group> _dbSet;

        public GroupRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Group>();
        }

        public IEnumerable<Group> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Group> Get(Func<Group, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Group> GetAll()
        {
            return _dbContext.Groups;
        }

        public Group Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Group Group)
        {
            _dbContext.Groups.Add(Group);
            Save();
        }

        public void Update(Group Group)
        {
            _dbSet.Update(Group);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return _dbContext.Groups.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Group Group = _dbSet.Find(id);
            if (Group != null)
                _dbSet.Remove(Group);
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
