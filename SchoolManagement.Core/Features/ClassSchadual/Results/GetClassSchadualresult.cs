namespace SchoolManagement.Core.Features.ClassSchadual.Results
{
    public class GetClassSchadualResult
    {
        public string TeacherName { get; set; } = null!;

        public byte Stage { get; set; }

        public byte ClassNumber { get; set; }

        public string Day { get; set; } = null!;

        public string Time { get; set; } = null!;
    }
}
