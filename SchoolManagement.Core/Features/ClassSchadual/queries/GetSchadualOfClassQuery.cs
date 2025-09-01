using Azure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.ClassSchadual.queries
{
    public record GetSchadualOfClassQuery:IRequest<Response<>>
    {

    }
}
