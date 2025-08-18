using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Teachers.Queries
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Bases;

    public record GetTeacherByIdQuery(string ssn):IRequest<Response<Teacher>>
    {
    }
}
