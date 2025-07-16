using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class Student
    {
        [Key]
        public string Id { get; set; } = null!;

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
        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Display(Name = "Family phone")]
        public string Phone { get; set; } = null!;
        public string ClassId { get; set; } = null!;
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; } = null!;
        
        public Student()
        {
            string year = DateTime.Now.Year.ToString().Substring(2);
            string centryCode = DateTime.Now.Year.ToString().Substring(1, 1);
            string randomPart = new Random().Next(1000, 9999).ToString();
            Id = $"{year}{centryCode}{randomPart}";
        }


    }
}
