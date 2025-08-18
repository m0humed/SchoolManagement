using AutoMapper;
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Class.Commands;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Class.Handlers
{
    using Schoolmanagement.Domain.Entities;
    public class EditClassHandler : ResponseHandler, IRequestHandler<EditClassCommand, Response<bool>>
    {
        #region Fields
        private readonly IClassService _classService;
        private readonly IMapper _map;
        #endregion

        #region Constructors
        public EditClassHandler(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _map = mapper;
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
