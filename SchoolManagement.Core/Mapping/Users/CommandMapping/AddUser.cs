using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Schoolmanagement.Domain.Entities.Identity;
using SchoolManagement.Core.Features.Users.Commands;

namespace SchoolManagement.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        private readonly PasswordHasher<Object> _hasher = new PasswordHasher<object>();

        private void AddUser()
        {
            CreateMap<AddUserCommand, User>()
                .ForMember(dest => dest.NormalizedEmail, cor => cor.MapFrom(src => src.Email.ToUpper()))
                //.ForMember(dest => dest.PasswordHash, cor => cor.MapFrom(src => _hasher.HashPassword(null, src.Password)))
                .ForMember(dest => dest.NormalizedUserName, cor => cor.MapFrom(src => src.UserName.ToUpper()))
                ;
        }


    }
}
