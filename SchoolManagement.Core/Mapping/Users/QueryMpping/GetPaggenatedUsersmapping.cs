using AutoMapper;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Features.Users.Results;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        private void GetPaggenatedUsersmapping()
        {
            CreateMap<User, GetPaginatedUsersResult>();

        }
    }
}
