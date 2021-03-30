/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.ConsoleApplications
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static IOrganizationService crmService = Helper.CRM_Service();
        static void Main(string[] args)
        {
            Console.WriteLine("testing crm connection");
        }
    }
}
