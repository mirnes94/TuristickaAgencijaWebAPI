using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TuristickaAgencija.MobileApp.Models
{
    public class EmailHelper
    {

        public bool SendEmail(string userEmail, string confirmationLink)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("mirnest10@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("mirnest10@gmail.com", "mirnes12345*");
            client.Host = "smtp.gmail.com";
            client.Port = 465;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
