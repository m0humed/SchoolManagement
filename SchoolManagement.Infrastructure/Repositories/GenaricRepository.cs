using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class GenaricRepository<T, ID> : IRepository<T, ID>
        where T : class
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructors
        public GenaricRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        #endregion

        #region Actions

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ID id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(ID id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(ID id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
