using System;
using Microsoft.EntityFrameworkCore;
using Examiner.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Examiner.DAL.EF
{
    public class ExaminerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ExaminerDbContext(DbContextOptions<ExaminerDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
//            Database.EnsureCreated();
        }
        public DbSet<User> Users_ { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
