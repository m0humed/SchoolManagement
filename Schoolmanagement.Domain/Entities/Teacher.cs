using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public string ssn { get; set; }
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
        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Phone]
        public string PhoneNumber { get; set; } = null!;


    }
}
