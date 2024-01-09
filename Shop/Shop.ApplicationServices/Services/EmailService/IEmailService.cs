using Shop.Core.Dto.EmailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);

    }
}
