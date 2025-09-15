namespace Schoolmanagement.Domain.Helper.Bind
{
    public class JwtSettings
    {
        public string secret { get; set; } = null!;
        public string issuer { get; set; } = null!;
        public string audience { get; set; } = null!;
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateIssuerSignInKey { get; set; }
    }
}
