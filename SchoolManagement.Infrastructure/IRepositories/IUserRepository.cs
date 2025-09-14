using Schoolmanagement.Domain.Entities.Identity;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetUserBySSNAsync(string ssn);
        Task<User?> GetUserByPhoneNumber(string phoneNumber);

    }
}
