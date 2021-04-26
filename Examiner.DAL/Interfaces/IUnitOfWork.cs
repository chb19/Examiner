using Examiner.DAL.EF;
using Examiner.DAL.Entities;
using Examiner.DAL.Interfaces;
using Examiner.DAL.Repositories;
using System;

namespace Examiner.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Group> Groups { get; }
        IRepository<Answer> Answers { get; }
        IRepository<TestResult> TestResults { get; }
        IRepository<Question> Questions { get; }
        IRepository<Test> Tests { get; }
        IRepository<AnswerStudent> AnswerStudents { get; }
        IRepository<GroupStudent> GroupStudents { get; }
        IRepository<GroupTest> GroupTests { get; }
        void Save();
    }
}
