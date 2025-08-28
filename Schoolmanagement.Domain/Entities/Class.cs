using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Schoolmanagement.Domain.Entities
{
    public class Class
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte Stage { get; set; }
        [Required]
        public byte ClassNumber { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Student.Class))]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        //public Class()
        //{
        //    Id = Guid.NewGuid();
        //}
    }
}
