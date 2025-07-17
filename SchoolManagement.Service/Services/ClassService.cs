using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.Services
{
    internal class ClassService: IClassService
    {
        #region Fields
        private readonly IClassRepositoy _classRepositoy;
        #endregion
        #region Constructor
        public ClassService(IClassRepositoy classRepositoy)
        {
            _classRepositoy = classRepositoy;
        }
        #endregion
        #region Methods
        public async Task AddAsync(Class entity)
        {
            await _classRepositoy.AddAsync(entity);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _classRepositoy.DeleteAsync(id);
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _classRepositoy.ExistsAsync(id);
        }
        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _classRepositoy.GetAllAsync();
        }
        public async Task<Class> GetByIdAsync(Guid id)
        {
            return await _classRepositoy.GetByIdAsync(id);
        }

        public Task UpdateAsync(Class entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
