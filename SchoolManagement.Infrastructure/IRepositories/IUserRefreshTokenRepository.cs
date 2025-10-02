using Schoolmanagement.Domain.Entities.Identity;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface IUserRefreshTokenRepository : IRepository<UserRefreshToken, Guid>
    {
        Task<UserRefreshToken?> GetTokenByUserId(string username);
    }
}
