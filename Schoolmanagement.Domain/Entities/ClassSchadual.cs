using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class ClassSchadual
    {
        [Required]
        public string ClassId { get; set; } = null!;

        [Required]
        public string SubjectId { get; set; } = null!;

        [Required]
        public string TeacherId { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }


        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; } = null!;

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; } = null!;

    }
}
