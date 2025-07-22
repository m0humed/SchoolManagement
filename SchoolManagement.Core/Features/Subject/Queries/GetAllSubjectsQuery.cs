using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Queries
{
    using Schoolmanagement.Domain.Entities;

    public record GetAllSubjectsQuery:IRequest<IEnumerable<Subject>>
    {
    }
}
