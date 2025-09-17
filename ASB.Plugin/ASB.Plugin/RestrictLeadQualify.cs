/// <copyright file="RestrictLeadQualify.cs">
/// Developed by Amar Singh
/// </copyright>

namespace ASB.Plugin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xrm.Sdk;
    using ASB.Plugin.Models;
    using ASB.Plugin.Utility;
    public class RestrictLeadQualify : IPlugin
    {
        /// <summary>
        /// this function will check if email contains data for lead.Lead can be qualify only when email present. 
        /// register - QualifyLead - Syncronous- sandbox - Pre/Post Operation - database
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Execute(IServiceProvider serviceProvider)
        {
            var pluginObject = PluginUtility.CRMService(serviceProvider);
            try
            {
                pluginObject.tracingService.Trace("Message: " + pluginObject.context.MessageName.ToUpper());
                if (pluginObject.context.MessageName.ToUpper() != LeadConstants.QUALIFYLEAD) { return; }
                EntityReference leadid = (EntityReference)pluginObject.context.InputParameters[LeadConstants.LEADSCHEMAID];
                var lead = Helper.GetEntityById(pluginObject.service, LeadConstants.ENTITYSCHEMANAME, leadid.Id, new string[] { LeadConstants.FULLNAME, LeadConstants.EMAIL });
                if (lead != null)
                {
                    pluginObject.tracingService.Trace("Email : " + lead.GetAttributeValue<string>(LeadConstants.EMAIL));
                    if (string.IsNullOrEmpty(lead.GetAttributeValue<string>(LeadConstants.EMAIL)))
                    {
                        throw new InvalidPluginExecutionException("Lead cannot be qualified without email.");
                    }
                }

            }
            catch (InvalidPluginExecutionException ex)
            {
                throw ex;
            }

        }
    }
}
