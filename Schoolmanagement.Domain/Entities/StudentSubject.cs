using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities
{
    public class StudentSubject
    {
        [Required]
        public string StudentId { get; set; } = null!;

        [Required]
        public Guid SubjectId { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Student.StudentSubjects))]
        public virtual Student Student { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.StudentSubjects))]
        public virtual Subject Subject { get; set; } = null!;

        public ushort? MidtermScore { get; set; }

        public ushort? FinalScore { get; set; }

        public ushort? ProjectScore { get; set; }

    }
}
