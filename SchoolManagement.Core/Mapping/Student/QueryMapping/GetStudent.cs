namespace SchoolManagement.Core.Mapping.Student
{
    using Schoolmanagement.Domain.Entities;
    using SchoolManagement.Core.Features.Student.Results;

    public partial class StudentProfile
    {
        public void GetStudent()
        {
            CreateMap<Student, GetStudentDataResult>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.GetLocalizer().Item1))
                .ForMember(dest => dest.MiddleName, act => act.MapFrom(src => src.GetLocalizer().Item2))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.GetLocalizer().Item3))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.GetLocalizer().Item4))
                .ForMember(dest => dest.classNumber, act => act.MapFrom(src => src.Class.ClassNumber))
                .ForMember(dest => dest.classStage, act => act.MapFrom(src => src.Class.Stage));
        }
    }
}
