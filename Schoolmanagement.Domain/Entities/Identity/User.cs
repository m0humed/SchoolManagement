using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Enums;

namespace Schoolmanagement.Domain.Entities.Identity
{
    public class User : IdentityUser
    {

        public string ssn { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Address { get; set; }
    }
}
