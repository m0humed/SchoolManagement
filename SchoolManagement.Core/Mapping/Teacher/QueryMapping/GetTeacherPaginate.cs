namespace SchoolManagement.Core.Mapping.Teacher
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Features.Teachers.Results;

    public partial class TeacherProfile
    {

        public void GetTeacherPaginate()
        {
            CreateMap<Teacher, GetTeachersPaginateResult>()
                .ForMember(des => des.FullName, act => act.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"));

        }
    }
}
