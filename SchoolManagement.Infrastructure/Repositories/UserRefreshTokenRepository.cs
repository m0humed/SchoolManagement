using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository : GenaricRepository<UserRefreshToken, Guid>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
