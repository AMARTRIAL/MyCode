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
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public  static class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <param name="columns"></param>
        /// <returns>Respective Entity With Selected Columns</returns>
        public static Entity GetEntityById(IOrganizationService service,string entity, Guid id, string[] columns)
        {
            Entity resultEntity = null;
            if (id != Guid.Empty)
                resultEntity = service.Retrieve(entity, id, new ColumnSet(columns));
            return resultEntity;
        }
        /// <summary>
        /// send email to contact
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
