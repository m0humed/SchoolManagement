using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Features.Autherization.Results;

namespace SchoolManagement.Core.Mapping.Autherization
{
    public partial class AuthorizeProfile
    {
        void GetRoleByIdMapper()
        {
            CreateMap<IdentityRole, GetRoleByIdResult>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
