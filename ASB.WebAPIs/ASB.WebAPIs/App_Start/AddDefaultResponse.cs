//<copyright file="AddDefaultResponse">
//Developed by Amar Singh
//<copyright/>
namespace ASB.WebAPI.App_Start
{
    using Swashbuckle.Swagger;
    using System.Web.Http.Description;
    public class AddDefaultResponse : IOperationFilter
    {
        /// <summary>
        /// Add default response in swagger
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.responses.Add("401", new Response { description = "The request did not have the correct authorization header." });
            operation.responses.Add("400", new Response { description = "The request did not have required parameters or is not in correct pattern." });
            operation.responses.Add("500", new Response { description = "There is some internal error. Check your log for details." });
            operation.responses.Add("404", new Response { description = "The endpoint you are trying to access is not available." });
        }
    }
}