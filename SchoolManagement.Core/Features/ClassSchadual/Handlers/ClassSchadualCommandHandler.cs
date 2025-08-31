using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.ClassSchadual.Commands;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.ClassSchadual.Handlers
{
    using Schoolmanagement.Domain.Entities;
    public class ClassSchadualCommandHandler : ResponseHandler, IRequestHandler<AddClassSchadualCommand, Response<bool>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IClassSchadualService _classSchadualService;
        private readonly IMapper _mapper;
        #endregion

        public ClassSchadualCommandHandler(IStringLocalizer<SharedResources> localizer, IClassSchadualService classSchadualService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _classSchadualService = classSchadualService;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddClassSchadualCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<bool>(_localizer[SharedResourcesKeys.nullValue]);
            }
            try
            {
                var schadual = _mapper.Map<ClassSchadual>(request);
                await _classSchadualService.AddAsync(schadual);
                return Created<bool>(true);
            }
            catch (Exception ex)
            {
                return ServerError<bool>(_localizer[SharedResourcesKeys.CanNotSave]);
            }
        }
    }
}
