using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;

using MailKit.Net.Smtp;
using Shop.ApplicationServices.Services.EmailService;
using Shop.Core.Dto.EmailDto;
using MailKit;
using Shop.Models.Email;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailServices;

        public EmailController(IEmailService emailServices)
        {
            _emailServices = emailServices;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmailDto dto = new EmailDto()
                {
                    To = model.To,
                    Subject = model.Subject,
                    Body = model.Body
                };

                _emailServices.SendEmail(dto);
                return View(model);
            }

            return View(nameof(Index));
        }
    }




}
