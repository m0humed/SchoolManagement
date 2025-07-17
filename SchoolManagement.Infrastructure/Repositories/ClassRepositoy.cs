using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            await DbContext.Classes.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) {
                throw new ArgumentException("Invalid class ID.", nameof(id));
            }
            var entity = DbContext.Classes.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Class with ID {id} not found.");
            }
            await Task.Run(() => DbContext.Classes.Remove(entity));

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

        public Task<Class> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Class entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
