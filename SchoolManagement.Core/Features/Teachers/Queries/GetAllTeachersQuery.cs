using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Teachers.Queries
{
    using SchoolManagement.Core.Bases;
    using Schoolmanagement.Domain.Entities;

    public record GetAllTeachersQuery:IRequest<Response<IEnumerable<Teacher>>>
    {
    }
}
