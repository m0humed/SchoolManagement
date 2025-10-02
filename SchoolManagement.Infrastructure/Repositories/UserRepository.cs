using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class UserRepository : GenaricRepository<User, Guid>, IUserRepository
    {
        #region Fileds
        private readonly ApplicationDbContext _context;
        #endregion
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.PhoneNumber != null && x.PhoneNumber.Equals(phoneNumber));
        }

        public async Task<User?> GetUserBySSNAsync(string ssn)
        {
            return await _context.Users
               .FirstOrDefaultAsync(x => x.ssn != null && x.ssn.Equals(ssn));
        }
    }
}
