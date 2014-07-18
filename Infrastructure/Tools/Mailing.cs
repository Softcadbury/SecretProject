namespace Infrastructure.Tools
{
    using System.Net;
    using System.Net.Mail;

    /// <summary>
    /// Class to manage emails
    /// </summary>
    public static class Mailing
    {
        /// <summary>
        /// Send a contact email
        /// </summary>
        public static void SendContact(string subject, string body)
        {
            Send(Settings.MailingContactFrom, Settings.MailingContactTo, "Contact : " + subject, body);
        }

        /// <summary>
        /// Send an email
        /// </summary>
        public static void Send(string from, string to, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            var smtpClient = new SmtpClient(Settings.SmtpHost);
            smtpClient.Credentials = new NetworkCredential(Settings.SmtpUserName, Settings.SmtpPassword);
            smtpClient.Send(mail);
        }
    }
}