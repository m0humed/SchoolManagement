using MailKit.Net.Smtp;
using MimeKit;
using Schoolmanagement.Domain.Common;
using Schoolmanagement.Domain.Enums;
using Schoolmanagement.Domain.Helper.Bind;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class EmailService : IEmailService
    {
        #region Fields
        private readonly EmailSettings _settings;

        #endregion

        #region Constructors
        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }
        #endregion
        #region Methods
        public async Task<string> SendEmailAsync(string email, string message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_settings.Connection, 587);
                    await client.AuthenticateAsync(_settings.MyEmail, _settings.MyPassword);
                    var bodyBuilder = new BodyBuilder()
                    {
                        HtmlBody = $"{message}",
                        TextBody = "I'm gonna become rich"
                    };
                    var messageBuild = new MimeMessage
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };
                    messageBuild.From.Add(
                        new MailboxAddress("Kory", _settings.MyEmail));
                    messageBuild.To.Add(
                        new MailboxAddress("Ali", email));
                    messageBuild.Subject = "😎";
                    await client.SendAsync(messageBuild);
                    await client.DisconnectAsync(true);
                    return "Success";
                }
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<ServiceResult> SendVerifyurlByEmailAsync(string email, string url)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_settings.Connection, 587);
                    await client.AuthenticateAsync(_settings.MyEmail, _settings.MyPassword);
                    var bodyBuilder = new BodyBuilder()
                    {
                        HtmlBody = $@"
                            <div style='font-family:Segoe UI,Arial,sans-serif;'>
                                <h2>Welcome to Kory School!</h2>
                                <p>Hi {email.Split("@")[0]},</p>
                                <p>Thank you for registering with <strong>Kory School</strong>.<br>
                                To activate your account and start exploring our platform, please verify your email address.</p>
                                <p>
                                    <a href='{url}' style='display:inline-block;padding:10px 20px;background:#0078D4;color:#fff;text-decoration:none;border-radius:4px;'>Verify Email</a>
                                </p>
                                <p>If you did not sign up for Kory School, please ignore this email.</p>
                                <br>
                                <p>Best regards,<br>
                                The Kory School Team</p>
                            </div>",
                        //TextBody = "Welcome to Kory School! Please verify your email to activate your account."
                    };
                    var messageBuild = new MimeMessage
                    {
                        Body = bodyBuilder.ToMessageBody()
                    };
                    messageBuild.From.Add(
                        new MailboxAddress("Kory School", _settings.MyEmail));
                    messageBuild.To.Add(
                        new MailboxAddress(email.Split("@")[0], email));
                    messageBuild.Subject = "Please verify your email address";
                    await client.SendAsync(messageBuild);
                    await client.DisconnectAsync(true);
                    return new ServiceResult
                    {
                        Success = true,
                        Message = "Virevication url sent successfully",
                        ServiceError = ServiceErrorEnum.None
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message,
                    ServiceError = ServiceErrorEnum.CanNotSendUrl
                };
            }
        }
        #endregion
    }
}
