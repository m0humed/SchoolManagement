using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities
{
    public class ClassSchadual
    {
        [Required]
        public Guid ClassId { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public string TeacherId { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }


        [ForeignKey(nameof(ClassId))]
        [InverseProperty(nameof(Class.ClassSchaduals))]
        public virtual Class Class { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.ClassSchaduals))]
        public virtual Subject Subject { get; set; } = null!;

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(Teacher.ClassSchaduals))]
        public virtual Teacher Teacher { get; set; } = null!;

    }
}
