using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class StudentSubject
    {
        [Required]
        public string StudentId { get; set; } = null!;
        
        [Required]
        public string SubjectId { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        public short MidtermScore { get; set; }

        public short FinalScore { get; set; }

        public short ProjectScore { get; set; }

    }
}
