using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {

            #region Class
            builder.HasIndex(c => new { c.Stage, c.ClassNumber })
                            .IsUnique();

            builder
                .HasMany(c => c.ClassSchaduals)
                .WithOne(s => s.Class)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.Students)
                .WithOne(s => s.Class)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
