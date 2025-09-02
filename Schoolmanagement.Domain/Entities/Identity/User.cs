using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Enums;

namespace Schoolmanagement.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public Gender Gender { get; set; }
        public string? Address { get; set; }

        public string ssn { get; set; } = null!;
    }
}
