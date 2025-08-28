using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Schoolmanagement.Domain.Entities
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }

        public string Titel { get; set; } = null!;

        public ushort fullMarks { get; set; }

        public ushort passMarks { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(ClassSchadual.Subject))]
        public virtual ICollection<ClassSchadual>? ClassSchaduals { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject>? StudentSubjects { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(SubjectAttachment.Subject))]
        public virtual ICollection<SubjectAttachment>? SubjectAttachments { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(SubjectTeacher.Subject))]
        public virtual ICollection<SubjectTeacher>? SubjectTeachers { get; set; }

        public Subject()
        {
            Id = Guid.NewGuid();
            ClassSchaduals = new HashSet<ClassSchadual>();
            StudentSubjects = new HashSet<StudentSubject>();
            SubjectAttachments = new HashSet<SubjectAttachment>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }
    }
}
