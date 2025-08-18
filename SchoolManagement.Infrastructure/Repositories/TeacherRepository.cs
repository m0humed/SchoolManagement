using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {

        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region CTOR
        public TeacherRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task AddAsync(Teacher entity)
        {
            if (await ExistsAsync(entity.ssn))
                throw new Exception("already exist");

            if (!await CheckSSNFormat(entity.ssn))
                throw new Exception("SSN not Valid");


            await _dbContext.Teachers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> CheckSSNFormat(string ssn)
        {
            if (ssn == null)
            {
                return Task.FromResult(false);
            }
            if (ssn.Length != 14)
            {
                return Task.FromResult(false);
            }
            if (ssn.StartsWith('2') || ssn.StartsWith('3'))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public async Task DeleteAsync(string id)
        {
            if (!await ExistsAsync(id))
                throw new Exception("No Teacher with this id");
            _dbContext.Teachers.Remove(await GetByIdAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _dbContext.Teachers.AnyAsync(x => x.ssn == id);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _dbContext.Teachers.ToListAsync();
        }

        public IQueryable<Teacher> GetAllByQuerable()
        {
            return _dbContext.Teachers.AsNoTracking().AsQueryable();
        }

        public async Task<Teacher> GetByIdAsync(string id)
        {
            if (!await ExistsAsync(id))
            {
                throw new Exception("No Teacher with this id");
            }
            return await _dbContext.Teachers.FindAsync(id);

        }

        public Task UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
