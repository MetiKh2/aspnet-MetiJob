using MetiJob.Api.Contracts.EmailSender;
using MetiJob.Api.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetiJob.Api.Controllers
{
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailRequest request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
