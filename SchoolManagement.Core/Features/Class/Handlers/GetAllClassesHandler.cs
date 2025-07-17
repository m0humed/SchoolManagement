using MediatR;
using SchoolManagement.Core.Features.Class.Queries;
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

    public class GetAllClassesHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<Class>>
    {

        #region Fields
        private readonly IClassService _classService;
        #endregion

        #region Constructors
        public GetAllClassesHandler(IClassService classService)
        {
            this._classService = classService;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Class>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            // Validate the request
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "GetAllClassesQuery cannot be null.");
            }
            // Use the service to get all classes
            return await _classService.GetAllAsync();
        }
        #endregion

    }
}
