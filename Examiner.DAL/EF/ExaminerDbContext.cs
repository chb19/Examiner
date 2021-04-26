using System;
using Microsoft.EntityFrameworkCore;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Examiner.DAL.EF
{
    public class ExaminerDbContext : IdentityDbContext<User, Role, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=examiner;Username=postgres;Password=kekmem");

        public ExaminerDbContext(DbContextOptions<ExaminerDbContext> options) : base(options)
        {
/*            Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }
        public DbSet<User> Users_ { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<AnswerStudent> AnswerStudents { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }
        public DbSet<GroupTest> GroupTests { get; set; }
    }
}
