using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.ClassSchadual.queries;
using SchoolManagement.Core.Features.ClassSchadual.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.ClassSchadual.Handlers
{
    public class ClassSchadualQueryHandler : ResponseHandler, IRequestHandler<GetSchadualOfClassQuery, Response<IEnumerable<GetClassSchadualResult>>>
    {
        #region MyRegion
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IClassSchadualService _classSchadualService;
        private readonly IMapper _mapper;
        #endregion
        public ClassSchadualQueryHandler(IStringLocalizer<SharedResources> localizer, IClassSchadualService classSchadualService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _classSchadualService = classSchadualService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetClassSchadualResult>>> Handle(GetSchadualOfClassQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return NullRequest<IEnumerable<GetClassSchadualResult>>(_localizer[SharedResourcesKeys.nullValue]);
            }
            try
            {
                var result = await _classSchadualService.GetSchadualByClassIdAsync(request.ClassId);
                var mappedResult = _mapper.Map<IEnumerable<GetClassSchadualResult>>(result);
                return Success(mappedResult);
            }
            catch
            {
                return ServerError<IEnumerable<GetClassSchadualResult>>(_localizer[SharedResourcesKeys.error]);
            }



        }
    }
}
