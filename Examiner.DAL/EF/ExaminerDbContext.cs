using System;
using Microsoft.EntityFrameworkCore;
using Examiner.DAL.Models;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Examiner.DAL.EF
{
    public class ExaminerDbContext : IdentityDbContext<User, Role, Guid>
    {
        /*        public ExaminerDbContext(DbContextOptions<ExaminerDbContext> options)
                    : base(options)
                {
                }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=examiner;Username=postgres;Password=password");
            }
        }
        /*        public ExaminerDbContext()
                {
                    Database.EnsureDeleted();   
                    Database.EnsureCreated();
                }
        */
        public DbSet<User> Users { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
