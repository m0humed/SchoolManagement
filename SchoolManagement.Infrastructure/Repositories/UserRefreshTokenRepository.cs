using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository : GenaricRepository<UserRefreshToken, Guid>, IUserRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> _userRefreshTokens;
        #endregion
        #region Construcctors
        public UserRefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
            _userRefreshTokens = context.Set<UserRefreshToken>();
        }
        #endregion
        public async Task<UserRefreshToken?> GetTokenByUserId(string UserId)
        {
            return await _userRefreshTokens.FirstOrDefaultAsync(x => x.UserId.Equals(UserId));
        }

    }
}
