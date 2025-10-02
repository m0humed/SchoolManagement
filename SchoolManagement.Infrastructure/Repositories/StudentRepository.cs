using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;


        #endregion


        #region Constructors
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task AddAsync(Student entity)
        {
            try
            {
                await _context.Students.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return;
            }
            try
            {
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Students.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Class).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            if (!await ExistsAsync(id))
                return new();
            return await _context.Students.Include(s => s.Class).FirstAsync(x => x.Id.Equals(id))!;
        }

        public Task UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
