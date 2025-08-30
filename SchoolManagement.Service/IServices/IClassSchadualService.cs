using Schoolmanagement.Domain.Entities;
using SchoolManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
    public interface IClassSchadualService:IService<ClassService , Guid>
    {
        Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId);
        Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId);
    }
}
