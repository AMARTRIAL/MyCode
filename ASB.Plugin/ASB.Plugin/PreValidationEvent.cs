/// <copyright file="PreValidationEvent.cs">
/// Developed by Amar Singh
/// </copyright>

namespace ASB.Plugin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ASB.Plugin.Models;
    using ASB.Plugin.Utility;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public class PreValidationEvent : IPlugin
    {
        /// <summary>
        /// plugin registered in pre-validation stage(10). Syncronous - sandbox - database
        /// this function will check if contacts status is approved. If status is approved then associate the records with cropping else throw error and send email to contact
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Execute(IServiceProvider serviceProvider)
        {
            var pluginObject = PluginUtility.CRMService(serviceProvider);
            try
            {
                EntityReference targetEntity = null;
                string relationshipName = string.Empty;
                EntityReferenceCollection relatedEntities = null;
                EntityReference relatedEntity = null;
                if (pluginObject.context.MessageName.ToUpper() == GlobalConstants.ASSOCIATE)
                {
                    if (pluginObject.context.InputParameters.Contains("Relationship"))
                    {
                        relationshipName = pluginObject.context.InputParameters["Relationship"].ToString();
                    }
                    if (relationshipName != GlobalConstants.RELATIONSHIP_CONTACT_CROPPING) {
                        return;
                    }
                    
                    // Get Entity 1 reference from "Target" Key from context
                    if (pluginObject.context.InputParameters.Contains(GlobalConstants.TARGET) && pluginObject.context.InputParameters[GlobalConstants.TARGET] is EntityReference)
                    {
                        targetEntity = (EntityReference)pluginObject.context.InputParameters[GlobalConstants.TARGET];
                        pluginObject.tracingService.Trace("Target Entity : " + targetEntity.LogicalName);
                    }
                    // Get Entity 2 reference from  RelatedEntities Key
                    if (pluginObject.context.InputParameters.Contains(GlobalConstants.RELATEDENTITIES) && pluginObject.context.InputParameters[GlobalConstants.RELATEDENTITIES] is EntityReferenceCollection)
                    {
                        relatedEntities = pluginObject.context.InputParameters[GlobalConstants.RELATEDENTITIES] as EntityReferenceCollection;
                        relatedEntity = relatedEntities[0];
                        pluginObject.tracingService.Trace("Related Entity : "+ relatedEntity.LogicalName);
                        Entity contact = pluginObject.service.Retrieve(relatedEntity.LogicalName, relatedEntity.Id, new ColumnSet(GlobalConstants.STATUSCODE,GlobalConstants.EMAIL));
                        if(contact.GetAttributeValue<OptionSetValue>(GlobalConstants.STATUSCODE).Value != GlobalConstants.APPROVED)
                        {
                            //send email to contact
                           Helper.SendEmail(contact.GetAttributeValue<string>(GlobalConstants.EMAIL));
                            //throw exception
                            throw new InvalidPluginExecutionException("Contact status should be approved");
                        }
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
