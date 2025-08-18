using Schoolmanagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.IRepositories
{
    public interface ITeacherRepository:IRepository<Teacher,string>
    {
        Task<bool> CheckSSNFormat(string ssn);


    }
}
