using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class ClassRepositoy : IClassRepositoy
    {
        #region Fields
        private readonly ApplicationDbContext DbContext;
        #endregion

        #region Constructor
        public ClassRepositoy(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task AddAsync(Class entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Class entity cannot be null.");
            }
            if (entity.Id == Guid.Empty || DbContext.Classes.Any(x => x.Id == entity.Id))
            {
                entity.Id = Guid.NewGuid();
            }

            await DbContext.Classes.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid class ID.", nameof(id));
            }
            var entity = DbContext.Classes.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Class with ID {id} not found.");
            }
            DbContext.Classes.Remove(entity);
            await DbContext.SaveChangesAsync();

        }

        public Task<bool> ExistsAsync(Guid id)
        {

            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid class ID.", nameof(id));
            }
            return Task.FromResult(DbContext.Classes.Any(c => c.Id == id));

        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await DbContext.Classes.ToListAsync();
        }

        public async Task<Class> GetByIdAsync(Guid id)
        {
            var entity = await DbContext.Classes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
            {
                throw new Exception("Not found Class");
            }
            return entity;
        }

        public async Task UpdateAsync(Class entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Class entity cannot be null.");
            }
            var existingEntity = await GetByIdAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Class with ID {entity.Id} not found.");
            }
            existingEntity.Stage = entity.Stage;
            existingEntity.ClassNumber = entity.ClassNumber;

            DbContext.Classes.Update(existingEntity);
            await DbContext.SaveChangesAsync();
        }
        #endregion
    }
}
