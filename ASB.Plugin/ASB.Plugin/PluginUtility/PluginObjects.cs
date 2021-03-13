/// <copyright file="PluginObjects.cs">
/// Developed by Amar Singh
/// </copyright>
namespace ASB.Plugin
{
    using Microsoft.Xrm.Sdk;
    public class PluginObjects
    {
        public ITracingService tracingService { get; set; }
        public IPluginExecutionContext context { get; set; }
        public IOrganizationServiceFactory serviceFactory { get; set; }
        public IOrganizationService service { get; set; }
    }
}