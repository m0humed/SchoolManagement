using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;


namespace SchoolManagement.Service.Services
{
    public class ClassSchadualService : IClassSchadualService
    {
        #region Field
        private IClassSchadualRepository _classSchadualRepository;
        #endregion

        #region Constructors
        public ClassSchadualService(IClassSchadualRepository classSchadualRepository)
        {
            _classSchadualRepository = classSchadualRepository;
        }
        #endregion

        public async Task AddAsync(ClassSchadual entity)
        {
           await _classSchadualRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _classSchadualRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _classSchadualRepository.ExistsAsync(id);
        }

        public async Task<IEnumerable<ClassSchadual>> GetAllAsync()
        {
             return await _classSchadualRepository.GetAllAsync();
        }

        public Task<ClassSchadual> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId)
        {
            return await _classSchadualRepository.GetSchadualByClassIdAsync(classId);
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId)
        {
            return await _classSchadualRepository.GetSchadualByTeacherIdAsync(teacherId);
        }

        public Task UpdateAsync(ClassSchadual entity)
        {
            throw new NotImplementedException();
        }
    }
}
