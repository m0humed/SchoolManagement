using MediatR;
using SchoolManagement.Core.Features.Class.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Class.Handlers
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Service.IServices;
    using System.Threading;

    public class AddClassHandler : IRequestHandler<AddClassCommand>
    {
        #region Fields
        private readonly IClassService _classService;

        #endregion

        #region Constructors
        public AddClassHandler(IClassService classService)
        {
            _classService = classService;
        }
        #endregion

        #region Methods
        public async Task Handle(AddClassCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.c == null)
            {
                throw new ArgumentNullException(nameof(request), "AddClassCommand or Class cannot be null.");
            }
            // Validate the class entity
            if (request.c.Id == Guid.Empty)
            {
                request.c.Id = Guid.NewGuid(); // Assign a new ID if not provided
            }
            // Add the class using the service
            await _classService.AddAsync(request.c);   
        }

        #endregion

    }
}
