using AutoMapper;
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Class.Handlers
{
    using Microsoft.Extensions.Localization;
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Resources;

    public class EditClassHandler : ResponseHandler, IRequestHandler<EditClassCommand, Response<bool>>
    {
        #region Fields
        private readonly IClassService _classService;
        private readonly IMapper _map;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditClassHandler(IClassService classService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _classService = classService;
            _map = mapper;
            _localizer = localizer;
        }

        #endregion

        public async Task<Response<bool>> Handle(EditClassCommand request, CancellationToken cancellationToken)
        {
            //cheack
            if (request == null)
            {
                return NotFound<bool>("the object is null");
            }
            // check if Id is Exist
            var check = await _classService.ExistsAsync(request.Id);

            if (check == false)
            {

                return NotFound<bool>("No class with this ID");
            }

            // Mapping to class
            var mapped = _map.Map<Class>(request);
            if (mapped == null)
                return ServerError<bool>("Can't convert EditCommand To class");
            try
            {
                await _classService.UpdateAsync(mapped);
            }
            catch (Exception ex)
            {
                return ServerError<bool>(ex.Message);
            }
            return Success(true);
        }
    }
}
