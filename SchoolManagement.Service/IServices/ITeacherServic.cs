using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Enums;

namespace SchoolManagement.Service.IServices
{
    public interface ITeacherService : IService<Teacher, string>
    {
        public Task<bool> isNameExist(string Name);
        public IQueryable<Teacher> GetAllQuerable();
        public IQueryable<Teacher> FilterSearchinQuerable(string search);
        public IQueryable<Teacher> OrderTeachers(OrderingTeachers? orderBy, IQueryable<Teacher>? result);
    }
}
