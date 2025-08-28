using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities
{
    public class SubjectTeacher
    {
        [Required]
        public string TeacherId { get; set; } = null!;

        [Required]
        public Guid SubjectId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(Teacher.SubjectTeachers))]
        public virtual Teacher Teacher { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.SubjectTeachers))]
        public virtual Subject Subject { get; set; } = null!;

    }
}
