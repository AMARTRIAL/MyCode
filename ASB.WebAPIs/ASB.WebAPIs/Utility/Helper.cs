//<copyright file="Helper">
//Developed by Amar Singh
//</copyright>
namespace ASB.WebAPIs.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.Xrm.Sdk;
    using log4net;
    using System.Net;
    using System.Configuration;
    using System.ServiceModel.Description;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Crm.Sdk.Messages;
    using ASB.WebAPIs.Utility;
    using ASB.WebAPI.Models;

    public class Helper
    {
        public IOrganizationService orgService = null;
        /// <summary>
        /// CRM Connectivity - online D365
        /// </summary>
        /// <param name="url"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        internal IOrganizationService ConnectCRM(string url, ILog logger)
        {
            try
            {
                logger.Info("CRM connection started...");
                IOrganizationService organizationService = null;
                ClientCredentials clientCredentials = new ClientCredentials();
                clientCredentials.UserName.UserName = ConfigurationManager.AppSettings["userName"].ToString();
                clientCredentials.UserName.Password = ConfigurationManager.AppSettings["password"].ToString();

                // For Dynamics 365 Customer Engagement V9.X, set Security Protocol as TLS12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(url),null, clientCredentials, null);
                logger.Info("CRM connection success...");
                return organizationService;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Validating calling user 
        /// </summary>
        /// <returns> boolean value after authenicating request header</returns>
        internal bool IsValidRequestAuthentication()
        {
            var authHeaderToken = ConfigurationManager.AppSettings["AuthToken"].ToString();
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["AuthToken"];
            if (authHeader != null)
            {
                return authHeader.Equals(authHeaderToken) ? true : false;
            }
            return false;
        }
        internal LeadResponse CreateLead(IOrganizationService orgService, ILog logger, LeadRequest leadInfo)
        {
            try
            {
                logger.Info("Create Lead started");
                LeadResponse response = new LeadResponse();
                Entity lead = new Entity("lead");
                if (!string.IsNullOrEmpty(leadInfo.subject))
                {
                    lead.Attributes["subject"] = leadInfo.subject;
                }
                if (!string.IsNullOrEmpty(leadInfo.firstName))
                {
                    lead.Attributes["firstname"] = leadInfo.firstName;
                }
                if (!string.IsNullOrEmpty(leadInfo.lastName))
                {
                    lead.Attributes["lastname"] = leadInfo.lastName;
                }
                if (!string.IsNullOrEmpty(leadInfo.jobTitle))
                {
                    lead.Attributes["jobtitle"] = leadInfo.jobTitle;
                }
                if (!string.IsNullOrEmpty(leadInfo.emailAddress))
                {
                    lead.Attributes["emailaddress1"] = leadInfo.emailAddress;
                }
                Guid leadId = orgService.Create(lead);
                response.leadId = leadId.ToString();
                response.message = "Lead sucessfully created";
                logger.Info("Lead Sucessfully created in CRM");
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex.InnerException.ToString());
                throw new Exception(ex.InnerException.ToString());
            }
        }
    }
}