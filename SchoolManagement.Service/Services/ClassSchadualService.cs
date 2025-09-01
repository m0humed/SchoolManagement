using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;


namespace SchoolManagement.Service.Services
{
    public class ClassSchadualService : IClassSchadualService
    {
        #region Field
        private IClassSchadualRepository _classSchadualReository;
        #endregion

        #region Constructors
        public ClassSchadualService(IClassSchadualRepository classSchadualRepository)
        {
            _classSchadualReository = classSchadualRepository;
        }
        #endregion

        public async Task AddAsync(ClassSchadual entity)
        {
            await _classSchadualReository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _classSchadualReository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _classSchadualReository.ExistsAsync(id);
        }

        public async Task<IEnumerable<ClassSchadual>> GetAllAsync()
        {
            return await _classSchadualReository.GetAllAsync();
        }

        public Task<ClassSchadual> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId)
        {
            return await _classSchadualReository.GetSchadualByClassIdAsync(classId);
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId)
        {
            return await _classSchadualReository.GetSchadualByTeacherIdAsync(teacherId);
        }

        public async Task UpdateAsync(ClassSchadual entity)
        {
            await _classSchadualReository.UpdateAsync(entity);
        }
    }
}
