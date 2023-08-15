using Email.Interface;
using Log.Interface;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace Email.Implementacao
{
    public class EmailSender : IEmailSender
    {
        private readonly IRegistro _registro;
        public EmailSender(IRegistro registro)
        {
            _registro = registro;
        }

        /// <summary>
        ///     Método utilizado para o envio de email.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="fromName"></param>
        /// <param name="toName"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void SendEmail(string from, string  fromName, string toName, string to, string subject, string body)
        {
            try
            {
                if(!EmailValidate(from) || !EmailValidate(to))
                    throw new ArgumentException("Email inválido");

                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress(fromName, from));
                mailMessage.To.Add(new MailboxAddress(toName, to));
                mailMessage.Subject = subject;
                mailMessage.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtpClient.Authenticate("", "");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
            }
            catch(ArgumentException argumentException)
            {
                _registro.GravaRegistro(
                    argumentException,
                    argumentException.Message,
                    nameof(SendEmail),
                    argumentException.StackTrace ?? string.Empty);

                throw;
            }
            catch (Exception exception)
            {
                _registro.GravaRegistro(
                    exception,
                    exception.Message,
                    nameof(SendEmail),
                    exception.StackTrace ?? string.Empty);

                throw;
            }

        }

        /// <summary>
        ///  Método utilizado para verificar se o email é válido.
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="NotImplementedException"></exception>
        public bool EmailValidate(string email)
            => new System.Net.Mail.MailAddress(email).Address == email;
        
    }
}
