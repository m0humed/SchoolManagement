using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class TeacherService : ITeacherService
    {

        #region Fields
        private readonly ITeacherRepository _teacher;
        #endregion

        #region Constructors

        public TeacherService(ITeacherRepository teacher)
        {
            _teacher = teacher;
        }
        #endregion

        public async Task AddAsync(Teacher entity)
        {
            await _teacher.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _teacher.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _teacher.ExistsAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _teacher.GetAllAsync();
        }

        public Task<Teacher> GetByIdAsync(string id)
        {
            return _teacher.GetByIdAsync(id);
        }

        public async Task<bool> isNameExist(string Name)
        {
            var allFirstNames = (await GetAllAsync()).Select(x => x.FirstName).ToList();
            return allFirstNames.Contains(Name);
        }

        public Task UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
