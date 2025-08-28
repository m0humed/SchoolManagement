using AutoMapper;

namespace SchoolManagement.Core.Mapping.Student
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            addStudent();
            GetStudent();
        }
    }
}
