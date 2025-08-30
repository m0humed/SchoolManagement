using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;


namespace SchoolManagement.Service.Services
{
    public class ClassSchadualService : IClassSchadualService
    {
        #region Field
        private IClassSchadualRepository _classSchadualService;
        #endregion

        #region Constructors
        public ClassSchadualService(IClassSchadualRepository classSchadualRepository)
        {
            _classSchadualService = classSchadualRepository;
        }
        #endregion

        public async Task AddAsync(ClassSchadual entity)
        {
           await _classSchadualService.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _classSchadualService.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _classSchadualService.ExistsAsync(id);
        }

        public async Task<IEnumerable<ClassSchadual>> GetAllAsync()
        {
             return await _classSchadualService.GetAllAsync();
        }

        public Task<ClassSchadual> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId)
        {
            return await _classSchadualService.GetSchadualByClassIdAsync(classId);
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId)
        {
            return await _classSchadualService.GetSchadualByTeacherIdAsync(teacherId);
        }

        public async Task UpdateAsync(ClassSchadual entity)
        {
             await _classSchadualService.UpdateAsync(entity);
        }
    }
}
