using System;
using Examiner.DAL.EF;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Examiner.DAL.Repositories;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ExaminerDbContext _dbContext;

        private bool _disposed = false;

        public IRepository<User> Users { get; }
        public IRepository<Group> Groups { get; }
        public IRepository<Archive> Archives { get; }
        public IRepository<Answer> Answers { get; }
        public IRepository<TestResult> TestResults { get; }
        public IRepository<Question> Questions { get; }
        public IRepository<Test> Tests { get; }

        public EFUnitOfWork(
            ExaminerDbContext dbContext,
            IRepository<User> userRepository,
            IRepository<Group> groupRepository,
            IRepository<Archive> archiveRepository,
            IRepository<Test> testRepository,
            IRepository<Answer> answerRepository,
            IRepository<TestResult> testResultRepository,
            IRepository<Question> questionRepository)
        {
            _dbContext = dbContext;
            Users = userRepository;
            Groups = groupRepository;
            Tests = testRepository;
            TestResults = testResultRepository;
            Questions = questionRepository;
            Answers = answerRepository;
            Archives = archiveRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}