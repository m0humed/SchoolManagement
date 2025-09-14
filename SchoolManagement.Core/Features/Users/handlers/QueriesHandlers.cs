using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Users.Queries;
using SchoolManagement.Core.Features.Users.Results;
using SchoolManagement.Core.Resources;
using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.Users.handlers
{
    public class QueriesHandlers : ResponseHandler, IRequestHandler<GetPaginatedUsersQuery,
                                                       PaginationResult<GetPaginatedUsersResult>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion
        public QueriesHandlers(IStringLocalizer<SharedResources> localizer, IMapper mapper
                               , UserManager<User> userManager) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginationResult<GetPaginatedUsersResult>> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            request.PageSize = request.PageSize >= 1 ? request.PageSize : 10;
            request.PageIndex = request.PageIndex >= 1 ? request.PageIndex : 1;

            var PaginatedUser = await users.PaginationExtinsionAsync(request.PageIndex, request.PageSize);
            var result = _mapper.Map<List<GetPaginatedUsersResult>>(PaginatedUser.data);

            return PaginationResult<GetPaginatedUsersResult>.Success
            (
                _data: result,
                _pageSize: request.PageSize,
                _totalCount: PaginatedUser.totalCount,
                _currentPage: PaginatedUser.currentPage
            );

        }
    }
}
