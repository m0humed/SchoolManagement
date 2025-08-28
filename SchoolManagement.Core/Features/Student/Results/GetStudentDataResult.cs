namespace SchoolManagement.Core.Features.Student.Results
{
    public class GetStudentDataResult
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public byte classStage { get; set; }

        public byte classNumber { get; set; }

    }
}
