using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            #region Student
            builder
                .HasMany(c => c.StudentSubjects)
                .WithOne(s => s.Student)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
