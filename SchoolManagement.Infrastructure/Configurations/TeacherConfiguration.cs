using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            #region Teacher
            builder
                .HasMany(c => c.ClassSchaduals)
                .WithOne(x => x.Teacher)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.Teachers)
                .WithOne(s => s.Supervisor)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.SubjectTeachers)
                .WithOne(s => s.Teacher)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

        }
    }
}
