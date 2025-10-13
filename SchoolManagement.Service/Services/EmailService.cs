using MailKit.Net.Smtp;
using MimeKit;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
    public class EmailService : IEmailService
    {
        public async Task<string> SendEmailAsync(string email, string message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var myEmail = "aa01224231342@gmail.com";
                    var myPassword = "pmhzhsztdfmrlgru";
                    await client.ConnectAsync("smtp.gmail.com", 587);
                    await client.AuthenticateAsync(myEmail, myPassword);
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
                        new MailboxAddress("Kory", myEmail));
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
    }
}
