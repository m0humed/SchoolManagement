using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.Services
{
    internal class SubjectService : ISubjectService
    {
        #region fields
        private readonly ISubjectRepository subject;
        #endregion

        #region ctors
        public SubjectService(ISubjectRepository subject)
        {
            this.subject = subject;
        }
        #endregion

        #region Methods
        public async Task AddAsync(Subject entity)
        {
            await subject.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await subject.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
             return  await subject.ExistsAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await subject.GetAllAsync();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
            return await subject.GetByIdAsync(id);
        }

        public async Task<Grades> Grade(int grade)
        {
            return await subject.Grade(grade); 
        }

        public Task UpdateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
