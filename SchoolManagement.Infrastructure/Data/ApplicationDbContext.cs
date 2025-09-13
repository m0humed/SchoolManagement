using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Entities.Identity;
using System.Reflection;

namespace SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //#region Class
            //modelBuilder.Entity<Class>()
            //                .HasIndex(c => new { c.Stage, c.ClassNumber })
            //                .IsUnique();

            //modelBuilder.Entity<Class>()
            //    .HasMany(c => c.ClassSchaduals)
            //    .WithOne(s => s.Class)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Class>()
            //    .HasMany(c => c.Students)
            //    .WithOne(s => s.Class)
            //    .OnDelete(DeleteBehavior.Restrict);
            //#endregion

            //#region ClassSchadual
            //modelBuilder.Entity<ClassSchadual>().
            //    HasKey(cs => new { cs.ClassId, cs.SubjectId, cs.TeacherId });

            //#endregion

            //#region Student
            //modelBuilder.Entity<Student>()
            //    .HasMany(c => c.StudentSubjects)
            //    .WithOne(s => s.Student)
            //    .OnDelete(DeleteBehavior.Cascade);

            //#endregion

            //#region StudentSubject

            //modelBuilder.Entity<StudentSubject>()
            //    .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            //#endregion

            //#region Subject
            //modelBuilder.Entity<Subject>()
            //    .HasIndex(s => s.Titel)
            //    .IsUnique();
            //modelBuilder.Entity<Subject>()
            //    .HasMany(C => C.ClassSchaduals)
            //    .WithOne(S => S.Subject)
            //    .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Subject>()
            //    .HasMany(C => C.StudentSubjects)
            //    .WithOne(S => S.Subject)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Subject>()
            //    .HasMany(C => C.SubjectTeachers)
            //    .WithOne(S => S.Subject)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Subject>()
            //    .HasMany(C => C.SubjectAttachments)
            //    .WithOne(S => S.Subject)
            //    .OnDelete(DeleteBehavior.Cascade);
            //#endregion


            //#region SubjectTeacher
            //modelBuilder.Entity<SubjectTeacher>()
            //       .HasKey(st => new { st.TeacherId, st.SubjectId });

            //#endregion

            //#region Teacher
            //modelBuilder.Entity<Teacher>()
            //    .HasMany(c => c.ClassSchaduals)
            //    .WithOne(x => x.Teacher)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.Teachers)
            //    .WithOne(s => s.Supervisor)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Teacher>()
            //    .HasMany(t => t.SubjectTeachers)
            //    .WithOne(s => s.Teacher)
            //    .OnDelete(DeleteBehavior.Cascade);
            //#endregion
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSchadual> classSchaduals { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }




    }
}
