using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<SubjectTeacher>()
                .HasKey(st => new { st.TeacherId, st.SubjectId });

            modelBuilder.Entity<ClassSchadual>().HasKey(cs => new { cs.ClassId, cs.SubjectId, cs.TeacherId });

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSchadual>  classSchaduals { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers  { get; set; }  




    }
}
