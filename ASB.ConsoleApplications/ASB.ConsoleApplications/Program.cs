/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.ConsoleApplications
{
    using Microsoft.Xrm.Sdk;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        public static IOrganizationService crmService = Helper.CRM_Service();
        static void Main(string[] args)
        {
            Console.WriteLine("testing crm connection");
        }
    }
}
