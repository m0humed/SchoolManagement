using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities
{
    public class SubjectAttachment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; } = null!;

        [Required]
        public string MimeType { get; set; } = null!;

        [Required]
        public string link { get; set; } = null!;

        [Required]
        public Guid SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.SubjectAttachments))]
        public virtual Subject Subject { get; set; } = null!;

    }
}
