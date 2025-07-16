using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class SubjectTeacher
    {
        [Required]
        public string TeacherId { get; set; } = null!;

        [Required]
        public Guid SubjectId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

    }
}
