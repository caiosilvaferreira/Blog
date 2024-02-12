using System.Net;
using System.Net.Mail;

namespace Blog.Services
{
    public class EmailService
    {

        public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "testes",
        string fromEmail = "caiosilvaferreira1@outlook.com.br")
        {
            var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);

            smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;    // o sendGrip sempre vai usar uma port segura que seria a 587
            smtpClient.EnableSsl = true;      // marcando que é uma porta segura
            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));           // seria uma lista
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mail);       // parte do envio
                return true;                    // try e catch caso der algum erro
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
