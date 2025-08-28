
using MediatR;
using SchoolManagement.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Student.Commands
{
    public record AddStudentCommand : IRequest<Response<bool>>
    {

        public string? Id { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string firstNameAr { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string secondNameAr { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string thirdNameAr { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string firstNameEn { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string secondNameEn { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string thirdNameEn { get; set; } = null!;

        public string AddressAr { get; set; } = null!;
        public string AddressEn { get; set; } = null!;


        [EmailAddress]
        public string Email { get; set; } = null!;

        //public DateTime DateOfBirth { get; set; }

        [Phone]
        [Display(Name = "Family phone")]
        public string Phone { get; set; } = null!;

        public Guid? ClassId { get; set; }

    }
}
