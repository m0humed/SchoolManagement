using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Class.Handlers
{
    using Schoolmanagement.Domain.Entities;
    public class ClassCommandHandler : ResponseHandler, IRequestHandler<AddClassCommand, Response<bool>>
                                                        , IRequestHandler<EditClassCommand, Response<bool>>
                                                        , IRequestHandler<DeleteClassCommand, Response<bool>>

    {
        #region Fields
        private readonly IClassService _classService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _map;
        #endregion
        #region Constructors
        public ClassCommandHandler(IClassService classService, IMapper map, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _localizer = localizer;
            _classService = classService;
            _map = map;
        }
        #endregion

        #region Handlers
        public async Task<Response<bool>> Handle(AddClassCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.c == null)
            {
                return NullRequest<bool>();
            }
            // Validate the class entity
            if (request.c.Id == Guid.Empty)
            {
                request.c.Id = Guid.NewGuid(); // Assign a new ID if not provided
            }
            // Add the class using the service
            try
            {
                await _classService.AddAsync(request.c);
                return Success<bool>(true);
            }
            catch
            {
                return ServerError<bool>();
            }

        }

        public async Task<Response<bool>> Handle(EditClassCommand request, CancellationToken cancellationToken)
        {
            //cheack
            if (request == null)
            {
                return NotFound<bool>();
            }
            // check if Id is Exist
            var check = await _classService.ExistsAsync(request.Id);

            if (check == false)
            {

                return NotFound<bool>();
            }

            // Mapping to class
            var mapped = _map.Map<Class>(request);
            if (mapped == null)
                return ServerError<bool>();
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

        public async Task<Response<bool>> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                return NullRequest<bool>();
            }
            try
            {
                if (!await _classService.ExistsAsync(request.Id))
                    return NotFound<bool>(_localizer[SharedResourcesKeys.notFound]);
                await _classService.DeleteAsync(request.Id);
                return Deleted<bool>();
            }
            catch
            {
                return ServerError<bool>();
            }
        }

        #endregion


    }
}
