using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Teachers.Results
{
    public class GetTeachersPaginateResult
    {
        public string FullName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Phone]
        public string PhoneNumber { get; set; } = null!;

    }
}
