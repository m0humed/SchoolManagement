using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface ITeacherRepository : IRepository<Teacher, string>
    {
        Task<bool> CheckSSNFormat(string ssn);
        IQueryable<Teacher> GetAllByQuerable();


    }
}
