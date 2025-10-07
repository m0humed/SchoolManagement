using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Features.Autherization.Results;

namespace SchoolManagement.Core.Mapping.Autherization
{
    public partial class AuthorizeProfile
    {
        void GetRoleListMapping()
        {
            CreateMap<IdentityRole, RolesListResult>()
                .ForMember(x => x.RoleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
