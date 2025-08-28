using Schoolmanagement.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities
{
    public class Student : LocalizerEntity
    {
        [Key]
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Display(Name = "Family phone")]
        public string Phone { get; set; } = null!;
        public Guid? ClassId { get; set; }
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
