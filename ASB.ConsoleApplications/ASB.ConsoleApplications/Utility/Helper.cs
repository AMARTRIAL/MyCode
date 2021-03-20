/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.ConsoleApplications
{
    using Microsoft.Xrm.Sdk;
    using System.Net;
    using System.Configuration;
    using Microsoft.Xrm.Tooling.Connector;
    using System.ServiceModel.Description;
    using System;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Crm.Sdk.Messages;

    public static class Helper
    {
       public static IOrganizationService CRM_Service()
        {
            IOrganizationService organizationService = null;
            Guid userId = Guid.Empty;
            //*************************************************************************//
            // Get the CRM connection string and connect to the CRM Organization
            ////working code
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CrmServiceClient crmConn = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRM"].ConnectionString);
            organizationService = crmConn.OrganizationServiceProxy;
            //*************************************************************************//
            //string OrgServiceUri = ConfigurationManager.AppSettings["URL"];
            //ClientCredentials clientCredentials = new ClientCredentials();
            //clientCredentials.UserName.UserName = ConfigurationManager.AppSettings["UserName"];
            //clientCredentials.UserName.Password = ConfigurationManager.AppSettings["Password"];
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //organizationService = (IOrganizationService)new OrganizationServiceProxy(new Uri(OrgServiceUri), null, clientCredentials, null);
            //*************************************************************************//
            //working code
            //CrmServiceClient crmServiceClient = new CrmServiceClient(ConfigurationManager.ConnectionStrings["CRM"].ConnectionString);
            //organizationService = (IOrganizationService)crmServiceClient.OrganizationWebProxyClient != null ?
            //    (IOrganizationService)crmServiceClient.OrganizationWebProxyClient :
            //    (IOrganizationService)crmServiceClient.OrganizationServiceProxy;
            //***************************************************************************//
            if (organizationService != null)
            {
                userId = ((WhoAmIResponse) organizationService.Execute(new WhoAmIRequest())).UserId;
            }
            if (userId != Guid.Empty)
            {
                Console.WriteLine("Connection successful.");
                Console.ReadLine();
            }

            return organizationService;
        }
       
    }
}
