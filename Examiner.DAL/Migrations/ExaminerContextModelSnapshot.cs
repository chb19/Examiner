using Examiner.DAL.EF;
using Examiner.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.DAL.Migrations
{
    [DbContext(typeof(ExaminerDbContext))]
    partial class ExaminerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);


            modelBuilder.Entity<Teacher>(entity =>
            {
                entity
                .ToTable("teacher");

                entity
                .Property(e => e.Id)
                .HasColumnName("id");

                entity
                .Property(e => e.Department)
                .HasColumnName("department")
                .HasColumnType("TEXT");

                entity
                .HasMany(e => e.Groups)
                .WithOne();

                entity
                .HasMany(e => e.Tests)
                .WithOne();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                .ToTable("student");

                entity
                .Property(e => e.Id)
                .HasColumnName("id");

                entity
                .Property(e => e.GradeBook)
                .HasColumnName("GradeBook");

                entity
                .HasMany(e => e.TestResults)
                .WithOne();

                entity
                .HasMany(p => p.Groups)
                .WithMany(q => q.Students)
                .UsingEntity(j => j.ToTable("GroupStudent"));

                entity
                .HasMany(p => p.Archives)
                .WithMany(q => q.Students)
                .UsingEntity(j => j.ToTable("ArchiveStudent"));
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); 

                entity
                .Property(e => e.Title)
                .HasColumnName("Title");

                entity
                .HasOne(e => e.Teacher)
                .WithMany(e => e.Groups)
                .HasForeignKey(e => e.TeacherId);

                entity
                .HasMany(p => p.Students)
                .WithMany(q => q.Groups)
                .UsingEntity(j => j.ToTable("GroupStudent"));

                entity
                .HasMany(p => p.Tests)
                .WithMany(q => q.Groups)
                .UsingEntity(j => j.ToTable("GroupTest"));
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity
                .Property(e => e.AnswerDate)
                .HasColumnName("AnswerDate");

                entity
                .Property(e => e.AnswerText)
                .HasColumnName("AnswerText");

                entity
                .Property(e => e.Correctness)
                .HasColumnName("Corectness");

                entity
                .HasMany(p => p.Archives)
                .WithMany(q => q.Answers)
                .UsingEntity(j => j.ToTable("AnswerArchive"));
            });
            
            modelBuilder.Entity<Question>(entity =>
            {
                entity
                .ToTable("question");

                entity
                .Property(e => e.Id).HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity
                .Property(e => e.CorrectAnswer)
                .HasColumnName("CorrectAnswer");

                entity
                .Property(e => e.QuestionText)
                .HasColumnName("QuestionText")
                .HasColumnType("TEXT");

                entity
                .HasOne(t => t.Test)
                .WithMany(q => q.Questions)
                .HasForeignKey(t => t.TestId);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity
                .ToTable("test");

                entity
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity
                .HasOne(t => t.Teacher)
                .WithMany(q => q.Tests)
                .HasForeignKey(t => t.TeacherId);

                entity
                .HasOne(t => t.Group)
                .WithMany(q => q.Tests)
                .HasForeignKey(t => t.GroupId);

                entity
                .HasMany(p => p.Questions)
                .WithOne();

                entity
                .HasMany(p => p.TestResults)
                .WithOne();

                entity
                .HasMany(p => p.Groups)
                .WithMany(q => q.Tests)
                .UsingEntity(j => j.ToTable("GroupTest"));
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity
                .ToTable("testResult");

                entity
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
                entity
                .Property(e => e.Grade)
                .HasColumnName("grade")
                .HasColumnType("INTEGER");

                entity
                .HasOne(t => t.Test)
                .WithMany(q => q.TestResults)
                .HasForeignKey(t => t.TestId);

                entity
                .HasOne(t => t.Student)
                .WithMany(q => q.TestResults)
                .HasForeignKey(t => t.StudentId);
            });


#pragma warning restore 612, 618
        }
    }
}
