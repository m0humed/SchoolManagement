using Schoolmanagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface IClassSchadualRepository:IRepository<ClassSchadual,Guid>
    {
        Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId);
        Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId);

    }
}
