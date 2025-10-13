namespace SchoolManagement.Service.IServices
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string message);
    }
}
