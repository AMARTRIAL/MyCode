/// <copyright file="Helper.cs">
/// Developed by Amar Singh
/// </copyright>


namespace ASB.Plugin.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using ASB.Plugin.Models;
    public  static class Helper
    {
        public static bool SendEmail(string email)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(GlobalConstants.FROMEMAIL);
                message.To.Add(new MailAddress(email));
                message.Subject = GlobalConstants.SUBJECT;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = GlobalConstants.BODY;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GlobalConstants.FROMEMAIL, GlobalConstants.PASSWORD);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
