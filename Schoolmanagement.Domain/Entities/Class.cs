using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        //public Class()
        //{
        //    Id = Guid.NewGuid();
        //}
    }
}
