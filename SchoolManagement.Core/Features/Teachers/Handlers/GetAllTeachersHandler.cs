using MediatR;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Teachers.Queries;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    public class GetAllTeachersHandler : ResponseHandler, IRequestHandler<GetAllTeachersQuery, Response<IEnumerable<Teacher>>>
    {
        private ITeacherService _service;

        public GetAllTeachersHandler(ITeacherService teacherService)
        {
            _service = teacherService;
        }
        public async Task<Response<IEnumerable<Teacher>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return  Success(await _service.GetAllAsync());
            
        }
    }
}
