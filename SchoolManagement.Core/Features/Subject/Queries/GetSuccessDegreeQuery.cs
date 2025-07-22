using MediatR;
using SchoolManagement.Core.Features.Subject.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Queries
{
    public record GetSuccessDegreeQuery(Guid subjectId):IRequest<SubjectSuccessDegreesResponse>
    {
    }
}
