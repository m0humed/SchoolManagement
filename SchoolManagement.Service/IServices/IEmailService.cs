using Schoolmanagement.Domain.Common;

namespace SchoolManagement.Service.IServices
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string email, string message);
        Task<ServiceResult> SendVerifyurlByEmailAsync(string email, string url);
    }
}
