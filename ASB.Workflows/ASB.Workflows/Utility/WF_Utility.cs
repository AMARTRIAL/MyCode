/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.Workflows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Workflow;
    using System.Activities;
    public static class WF_Utility
    {
        public static WorkflowObjects CrmService(CodeActivityContext context)
        {
            WorkflowObjects WorkflowObj = new WorkflowObjects();
            ITracingService TracingService = context.GetExtension<ITracingService>();
            IWorkflowContext WorkflowContext = context.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService Service = ServiceFactory.CreateOrganizationService(WorkflowContext.UserId);
            //assign Objects to Class
            WorkflowObj.tracingService = TracingService;
            WorkflowObj.workflowContext = WorkflowContext;
            WorkflowObj.serviceFactory = ServiceFactory;
            WorkflowObj.service = Service;
            return WorkflowObj;
        }
    }
}
