using AutoMapper;

namespace SchoolManagement.Core.Mapping.Autherization
{
    public partial class AuthorizeProfile : Profile
    {
        public AuthorizeProfile()
        {
            UpdateRole();
        }
    }
}
