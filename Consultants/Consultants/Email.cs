using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Consultants
{
    class Email
    {
        public void sendEmail(string messageBody, string receiver, string sender, string password)
        {
            var message = new MailMessage(sender, receiver);
            message.Subject = "Query Request";
            message.Body = messageBody;
            SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
            mailer.Credentials = new NetworkCredential(sender, password);
            mailer.EnableSsl = true;
            mailer.Send(message);
        }
    }
}
