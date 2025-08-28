using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Schoolmanagement.Domain.Entities
{
    public class Teacher
    {
        [Key]
        [Required]
        public string ssn { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; } = null!;

        public string? Address { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; } = null!;

        public string? SuppervisorSSN { get; set; } = null!;

        [JsonIgnore]
        [InverseProperty(nameof(ClassSchadual.Teacher))]
        public virtual ICollection<ClassSchadual>? ClassSchaduals { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(SubjectTeacher.Teacher))]
        public virtual ICollection<SubjectTeacher>? SubjectTeachers { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<Teacher>? Teachers { get; set; }

        [ForeignKey(nameof(SuppervisorSSN))]
        [InverseProperty(nameof(Teachers))]
        public virtual Teacher? Supervisor { get; set; }

        public Teacher()
        {
            ClassSchaduals = new HashSet<ClassSchadual>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

    }
}
