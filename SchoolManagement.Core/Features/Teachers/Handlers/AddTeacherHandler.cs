using MediatR;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Core.Features.Teachers.Commands;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Teachers.Handlers
{
    public class AddTeacherHandler : IRequestHandler<AddTeacherCommand>
    {
        #region fields
        private readonly ITeacherService _teacherService;
        #endregion

        #region Constructor
        public AddTeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        #endregion
        public async Task Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (request.Teacher == null) throw new Exception("null object");

            await _teacherService.AddAsync(request.Teacher);

        }
    }
}
