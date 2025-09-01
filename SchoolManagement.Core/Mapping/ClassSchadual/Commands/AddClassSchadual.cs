using SchoolManagement.Core.Features.ClassSchadual.Commands;

namespace SchoolManagement.Core.Mapping.ClassSchadual
{
    using Schoolmanagement.Domain.Entities;
    public partial class ClassSchadualProfile
    {

        void AddClassSchadual()
        {
            CreateMap<AddClassSchadualCommand, ClassSchadual>()
                .ForMember(dest => dest.StartTime, conf => conf.MapFrom(x => TimeOnly.Parse(x.StartTime)));

        }

    }
}
