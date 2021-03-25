using Examiner.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }


        // public AppDbContext(DbContextOptions<AppDbContext> options)
        //     : base(options)
        // {
        //     Database.EnsureCreated();
        // }
    }
}
