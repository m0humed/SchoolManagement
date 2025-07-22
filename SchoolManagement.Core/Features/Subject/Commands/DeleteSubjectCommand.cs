using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Commands
{
    using MediatR;
    public record DeleteSubjectCommand(Guid subjectId):IRequest
    {
    }
}
