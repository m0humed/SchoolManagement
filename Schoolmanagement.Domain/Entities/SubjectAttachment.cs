using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class SubjectAttachment
    {
        [Key]
        public Guid Id{ get; set; }

        [Required]
        public string FileName { get; set; } = null!;

        [Required]
        public string MimeType { get; set; } = null!;

        [Required]
        public string link { get; set; } = null!;

        [Required]
        public string SubjectId { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

    }
}
