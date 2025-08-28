using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

            #region Subject
            builder
                .HasIndex(s => s.Titel)
                .IsUnique();
            builder
                .HasMany(C => C.ClassSchaduals)
                .WithOne(S => S.Subject)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(C => C.StudentSubjects)
                .WithOne(S => S.Subject)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                  .HasMany(C => C.SubjectTeachers)
                .WithOne(S => S.Subject)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(C => C.SubjectAttachments)
                .WithOne(S => S.Subject)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

        }
    }
}
