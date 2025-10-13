using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Core.Features.Mail.Handlers
{
    public partial class CommandHandlers : ResponseHandler
    {
        #region Fields
        private IStringLocalizer<SharedResources> _localizer;
        private IEmailService _emailService;
        #endregion
        #region Constructors
        public CommandHandlers(IStringLocalizer<SharedResources> localizer, IEmailService emailService) : base(localizer)
        {
            _localizer = localizer;
            _emailService = emailService;
        }
        #endregion
    }
}
