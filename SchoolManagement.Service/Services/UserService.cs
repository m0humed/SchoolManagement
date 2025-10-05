using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion
        #region Constructors
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Methods
        public async Task AddAsync(User entity)
        {
            await _userRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _userRepository.ExistsAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsUserNameExistAsync(string UserName)
        {
            return await _userRepository.GetByNameAsync(UserName) != null;
        }

        public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userRepository.GetUserByPhoneNumber(phoneNumber);
        }

        public async Task<User?> GetUserBySSNAsync(string ssn)
        {
            return await _userRepository.GetUserBySSNAsync(ssn);
        }

        public async Task<bool> IsPhoneNumberExist(Guid id, string Phonenumber)
        {
            var user = await _userRepository.GetUserByPhoneNumber(Phonenumber);
            if (user == null)
                return false;
            if (user.PhoneNumber == null || user.Id.Equals(id.ToString())) return false;
            return true;
        }

        public async Task<bool> IsSSNExist(Guid id, string ssn)
        {
            var user = await _userRepository.GetUserBySSNAsync(ssn);
            if (user == null)
                return false;
            if (user.ssn == null || user.Id.Equals(id.ToString())) return false;
            return true;
        }

        public async Task UpdateAsync(User entity)
        {
            await _userRepository.UpdateAsync(entity);
        }

        #endregion
    }
}
