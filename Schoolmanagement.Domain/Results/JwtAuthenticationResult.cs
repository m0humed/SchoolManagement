namespace Schoolmanagement.Domain.Results
{
    public class JwtAuthenticationResult
    {
        public string AccountToken { get; set; } = null!;

        public RefreshToken RefreshToken { get; set; } = null!;

    }

    public class RefreshToken
    {
        public string UserName { get; set; } = null!;
        public string TokenString { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
    }
}
