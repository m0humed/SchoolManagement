using Schoolmanagement.Domain.Entities.Identity;

namespace SchoolManagement.Service.IServices
{
    public interface IUserService : IService<User, Guid>
    {

        Task<User?> GetUserBySSNAsync(string ssn);
        Task<User?> GetUserByPhoneNumber(string phoneNumber);

        Task<bool> IsSSNExist(Guid id, string ssn);
        Task<bool> IsPhoneNumberExist(Guid id, string phoneNumber);


    }
}
