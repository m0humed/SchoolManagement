using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class StudentService : IStudentService
    {
        #region Fields

        private readonly IStudentRepository _studentReposutory;


        #endregion
        #region Constructors

        public StudentService(IStudentRepository studentReposutory)
        {
            _studentReposutory = studentReposutory;
        }

        #endregion

        #region Methods

        public async Task AddAsync(Student entity)
        {

            await _studentReposutory.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _studentReposutory.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _studentReposutory.ExistsAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentReposutory.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _studentReposutory.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Student entity)
        {
            await _studentReposutory.UpdateAsync(entity);
        }
        #endregion
    }
}
