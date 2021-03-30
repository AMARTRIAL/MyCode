/// <copyright>
/// Developed by Amar Singh
/// </copyright>

namespace ASB.Workflows
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    internal static class Helper
    {
        public static EntityCollection GetTaxCodeMaster(WorkflowObjects wfObjects)
        {
            wfObjects.tracingService.Trace("Get Tax Code Started");
            QueryExpression query = new QueryExpression(Constants.TAXCODE_ENTITY);
            query.ColumnSet.Columns.Add(Constants.TAXCODENAME);
            query.ColumnSet.Columns.Add(Constants.TAXCODEID);
            return wfObjects.service.RetrieveMultiple(query);
        }
    }
}
