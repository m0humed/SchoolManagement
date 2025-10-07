using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Autherization.Queries;
using SchoolManagement.Core.Features.Autherization.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;
namespace SchoolManagement.Core.Features.Autherization.Handlers
{
    public class QueryHandlers : ResponseHandler, IRequestHandler<GetRolesListQuery, Response<List<RolesListResult>>>
                                                , IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>
                                                , IRequestHandler<GetUserAndRolesQuery, Response<GetUserAndHisRolesResult>>
                                                , IRequestHandler<GetUserClaimsQuery, Response<ManageUserClaimsResult>>
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

        public async Task<Response<GetUserAndHisRolesResult>> Handle(GetUserAndRolesQuery request, CancellationToken cancellationToken)
        {
            var getUserAndHisRolesResult = new GetUserAndHisRolesResult { UserName = request.UserName };

            // Get all roles
            var allRoles = await _autherizationService.GetAllAsync();
            // Get user roles
            var userRoles = await _autherizationService.GetRolesForUserAsync(request.UserName);

            // Create a set of role IDs the user has
            var userRoleIds = userRoles.Select(r => r.RoleId).ToHashSet();

            // Build the complete list
            var resultRoles = new List<UserRoles>();
            foreach (var role in allRoles)
            {
                var hasRole = userRoleIds.Contains(role.Id);
                // If user already has this role, use the existing UserRoles object, else create a new one with Has = false
                var userRole = userRoles.FirstOrDefault(r => r.RoleId == role.Id);
                if (userRole != null)
                {
                    resultRoles.Add(userRole);
                }
                else
                {
                    resultRoles.Add(new UserRoles
                    {
                        RoleId = role.Id,
                        RoleName = role.Name!,
                        HasRole = false
                    });
                }
            }

            getUserAndHisRolesResult.UserRoles = resultRoles;
            return Success(getUserAndHisRolesResult);
        }

        public async Task<Response<ManageUserClaimsResult>> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var result = await _autherizationService.GetClaimsForUserAsync(request.UserName);
            return Success(result);
        }

        #endregion
    }
}
