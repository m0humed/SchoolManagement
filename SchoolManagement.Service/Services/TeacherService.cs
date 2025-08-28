using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Enums;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class TeacherService : ITeacherService
    {

        #region Fields
        private readonly ITeacherRepository _teacher;
        #endregion

        #region Constructors

        public TeacherService(ITeacherRepository teacher)
        {
            _teacher = teacher;
        }
        #endregion

        public async Task AddAsync(Teacher entity)
        {
            await _teacher.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _teacher.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _teacher.ExistsAsync(id);
        }

        public IQueryable<Teacher> FilterSearchinQuerable(string search)
        {
            var items = GetAllQuerable();
            var result = items.Where(x => x.ssn.Contains(search) || x.FirstName.Contains(search)
                           || x.PhoneNumber!.Contains(search) || x.Email!.Contains(search));
            return result;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _teacher.GetAllAsync();
        }

        public IQueryable<Teacher> GetAllQuerable()
        {
            return _teacher.GetAllByQuerable();
        }

        public Task<Teacher> GetByIdAsync(string id)
        {
            return _teacher.GetByIdAsync(id);
        }

        public async Task<bool> isNameExist(string Name)
        {
            var allFirstNames = (await GetAllAsync()).Select(x => x.FirstName).ToList();
            return allFirstNames.Contains(Name);
        }

        public IQueryable<Teacher> OrderTeachers(OrderingTeachers? orderBy, IQueryable<Teacher>? result)
        {
            if (orderBy == null)
            {
                if (result == null)
                {
                    return GetAllQuerable();
                }
                else
                {
                    return result;

                }
            }
            else
            {
                if (result == null)
                {
                    switch (orderBy)
                    {
                        case OrderingTeachers.ssn:
                            return GetAllQuerable().OrderBy(x => x.ssn);
                        case OrderingTeachers.phone:
                            return GetAllQuerable().OrderBy(x => x.PhoneNumber);
                        case OrderingTeachers.email:
                            return GetAllQuerable().OrderBy(x => x.Email);
                        case OrderingTeachers.name:
                            return GetAllQuerable().OrderBy(x => x.FirstName).ThenBy(x => x.MiddleName).ThenBy(x => x.LastName);
                    }
                }
                switch (orderBy)
                {
                    case OrderingTeachers.ssn:
                        return result!.OrderBy(x => x.ssn);
                    case OrderingTeachers.phone:
                        return result!.OrderBy(x => x.PhoneNumber);
                    case OrderingTeachers.email:
                        return result!.OrderBy(x => x.Email);
                    case OrderingTeachers.name:
                        return result!.OrderBy(x => x.FirstName).ThenBy(x => x.MiddleName).ThenBy(x => x.LastName);
                    default:
                        return result!.OrderBy(x => x.ssn);
                }
            }
        }

        public Task UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
