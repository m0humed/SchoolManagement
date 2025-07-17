using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Class.Commands
{
    using MediatR;
    using Schoolmanagement.Domain.Entities;
    public record AddClassCommand(Class c):IRequest
    {

    }
}
