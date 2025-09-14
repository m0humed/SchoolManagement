using Schoolmanagement.Domain.Enums;

namespace SchoolManagement.Core.Features.Users.Results
{
    public class GetPaginatedUsersResult
    {
        public string ssn { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
