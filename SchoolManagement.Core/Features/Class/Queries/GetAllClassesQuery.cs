using MediatR;
using Schoolmanagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Class.Queries
{
    public record GetAllClassesQuery:IRequest<IEnumerable<Schoolmanagement.Domain.Entities.Class>>
    { }
}
