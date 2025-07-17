
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface IRepository<TEntity , ID>
    where TEntity : class
    {
        Task<TEntity> GetByIdAsync(ID id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(ID id);
        Task<bool> ExistsAsync(ID id);
    }
}
