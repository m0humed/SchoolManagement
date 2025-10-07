using System.Security.Claims;

namespace Schoolmanagement.Domain.Helper
{
    public static class ClaimStore
    {
        public static List<Claim> claims = new List<Claim>()
        {
            new Claim("Create Student","false"),
            new Claim("Edit Student","false"),
            new Claim("Delete Student","false"),
            new Claim("Create Teacher","false"),
            new Claim("Edit Teacher","false"),
            new Claim("Delete Teacher","false"),
        };

    }
}
