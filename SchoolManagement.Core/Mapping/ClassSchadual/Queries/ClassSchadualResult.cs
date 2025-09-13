using SchoolManagement.Core.Features.ClassSchadual.Results;

namespace SchoolManagement.Core.Mapping.ClassSchadual
{
    using Schoolmanagement.Domain.Entities;
    public partial class ClassSchadualProfile
    {

        void ClassSchadualResult()
        {
            CreateMap<ClassSchadual, GetClassSchadualResult>()
                .ForMember(dest => dest.Day, cof => cof.MapFrom(cs => Enum.GetName<DayOfWeek>(cs.DayOfWeek)))
                .ForMember(dest => dest.Time, cof => cof.MapFrom(cs => cs.StartTime.ToString()))
                .ForMember(dest => dest.Stage, cof => cof.MapFrom(cs => cs.Class.Stage))
                .ForMember(dest => dest.ClassNumber, cof => cof.MapFrom(cs => cs.Class.ClassNumber))
                .ForMember(dest => dest.TeacherName, cof => cof.MapFrom(cs => $"{cs.Teacher.FirstName} {cs.Teacher.MiddleName} {cs.Teacher.LastName}"))
                ;
        }

    }
}
