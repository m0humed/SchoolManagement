using AutoMapper;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Features.Users.Commands;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {

        private void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
