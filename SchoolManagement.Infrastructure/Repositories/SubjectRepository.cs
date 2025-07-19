using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors
        public SubjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion
        #region Methods
        public async Task AddAsync(Subject entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if(entity.Id ==  Guid.Empty || await ExistsAsync(entity.Id))
                entity.Id = Guid.NewGuid();
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentNullException($"No Subject with this ID {id}");
            _dbContext.Subjects.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbContext.Subjects.FindAsync(id) != null;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _dbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
             return await _dbContext.Subjects.FindAsync(id);
        }

        public Task<Grades> Grade(int degree)
        {

            // meqasal a3mel impelementation
            foreach (var field in typeof(Grades).GetFields())
            {
                var attribute = field.GetCustomAttributes(typeof(RangeAttribute), false)
                                     .FirstOrDefault() as RangeAttribute;

                if (attribute != null && attribute.IsValid(degree))
                {
                    return Task.FromResult((Grades)field.GetValue(null));
                }
            }

            throw new ArgumentOutOfRangeException(nameof(degree), "Degree out of expected range.");
        }

        public Task UpdateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
