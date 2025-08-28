using SchoolManagement.Core.Features.Student.Commands;

namespace SchoolManagement.Core.Mapping.Student
{
    using Schoolmanagement.Domain.Entities;
    public partial class StudentProfile
    {

        public void addStudent()
        {
            CreateMap<AddStudentCommand, Student>();
        }
    }
}
