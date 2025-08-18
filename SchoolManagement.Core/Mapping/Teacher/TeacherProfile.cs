using AutoMapper;

namespace SchoolManagement.Core.Mapping.Teacher
{
    public partial class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            GetTeacherPaginate();
        }
    }
}
