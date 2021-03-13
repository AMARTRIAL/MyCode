/// <copyright file="PluginUtility.cs">
/// Developed by Amar Singh
/// </copyright>
namespace ASB.Plugin
{
    using Microsoft.Xrm.Sdk;
    using System;

    public static class PluginUtility
    {
        public static PluginObjects CRMService(IServiceProvider serviceProvider)
        {
            PluginObjects pluginObjects = new PluginObjects();
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            //Assign Object to class object
            pluginObjects.tracingService = tracingService;
            pluginObjects.context = context;
            pluginObjects.serviceFactory = serviceFactory;
            pluginObjects.service = service;
            return pluginObjects;
        }

    }
}
