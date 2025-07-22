using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Commands
{
    using Schoolmanagement.Domain.Entities;
    public record UpdateSubjectCommand(Subject subject):IRequest
    {

    }
}
