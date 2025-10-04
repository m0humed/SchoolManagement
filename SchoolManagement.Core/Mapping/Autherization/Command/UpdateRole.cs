using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Dtos;

namespace SchoolManagement.Core.Mapping.Autherization
{
    public partial class AuthorizeProfile
    {
        private void UpdateRole()
        {
            CreateMap<UpdateRoleRequest, IdentityRole>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleName))
                ;
        }
    }
}
