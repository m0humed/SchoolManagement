using AutoMapper;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Features.Users.Results;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                ;
        }
    }
}
