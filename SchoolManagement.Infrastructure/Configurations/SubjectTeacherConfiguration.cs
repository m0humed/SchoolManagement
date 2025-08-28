using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            #region SubjectTeacher
            builder
                   .HasKey(st => new { st.TeacherId, st.SubjectId });

            #endregion

        }
    }
}
