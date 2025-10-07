namespace Schoolmanagement.Domain.Results
{
    public class ManageUserClaimsResult
    {
        public string UserName { get; set; } = null!;
        public List<UserClaims> userClaims { get; set; } = null!;
    }
    public class UserClaims
    {
        public string Type { get; set; } = null!;
        public bool Value { get; set; }
    }
}
