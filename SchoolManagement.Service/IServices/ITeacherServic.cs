using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Service.IServices
{
    public interface ITeacherService : IService<Teacher, string>
    {
        public Task<bool> isNameExist(string Name);

    }
}
