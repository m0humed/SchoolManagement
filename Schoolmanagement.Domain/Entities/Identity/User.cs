using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schoolmanagement.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }

        public string ssn { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string? Address { get; set; }

        [InverseProperty(nameof(UserRefreshToken.user))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
