using Schoolmanagement.Domain.Entities;
using Schoolmanagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.IServices
{
    public interface ISubjectService:IService<Subject,Guid>
    {
        Task<Grades> Grade(int grade);
    }
}
