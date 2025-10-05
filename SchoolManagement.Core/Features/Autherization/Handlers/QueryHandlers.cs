using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Queries;
using SchoolManagement.Core.Features.Autherization.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Autherization.Handlers
{
    public class QueryHandlers : ResponseHandler, IRequestHandler<GetRolesListQuery, Response<List<RolesListResult>>>
                                                , IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAutherizationService _autherizationService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public QueryHandlers(IStringLocalizer<SharedResources> localizer, IAutherizationService autherizationService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _autherizationService = autherizationService;
            _mapper = mapper;
        }
        #endregion
        #region Handlers
        public async Task<Response<List<RolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<List<RolesListResult>>();
            }
            var list = await _autherizationService.GetAllAsync();
            var mappedResult = _mapper.Map<List<RolesListResult>>(list);
            return Success(mappedResult);
        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<GetRoleByIdResult>();
            }
            try
            {
                var role = await _autherizationService.GetByIdAsync(request.Id);
                var mapped = _mapper.Map<GetRoleByIdResult>(role);
                return Success(mapped);
            }
            catch
            {
                return ServerError<GetRoleByIdResult>();
            }
        }

        #endregion
    }
}
