/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.Workflows
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    public class WorkflowObjects
    {
        public ITracingService tracingService { get; set; }
        public IWorkflowContext workflowContext { get; set; }
        public IOrganizationServiceFactory serviceFactory { get; set; }
        public IOrganizationService service { get; set; }
    }
}
