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
    public class ArchiveRepository : IRepository<Archive>
    {
        private readonly ExaminerDbContext _dbContext;

        private readonly DbSet<Archive> _dbSet;

        public ArchiveRepository(ExaminerDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Archive>();
        }

        public IEnumerable<Archive> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Archive> Get(Func<Archive, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Archive> GetAll()
        {
            return _dbContext.Archives;
        }

        public Archive Get(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Archive Archive)
        {
            _dbContext.Archives.Add(Archive);
        }

        public void Update(Archive Archive)
        {
            _dbSet.Update(Archive);
        }

        public IEnumerable<Archive> Find(Func<Archive, bool> predicate)
        {
            return _dbContext.Archives.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Archive Archive = _dbSet.Find(id);
            if (Archive != null)
                _dbSet.Remove(Archive);
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