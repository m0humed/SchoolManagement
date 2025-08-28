using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class ClassSchadualConfiguration : IEntityTypeConfiguration<ClassSchadual>
    {
        public void Configure(EntityTypeBuilder<ClassSchadual> builder)
        {
            #region ClassSchadual
            builder.
                HasKey(cs => new { cs.ClassId, cs.SubjectId, cs.TeacherId });

            #endregion
        }
    }
}
