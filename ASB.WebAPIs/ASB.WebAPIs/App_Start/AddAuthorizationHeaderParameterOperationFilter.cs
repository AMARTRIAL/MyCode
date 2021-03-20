//<copyright file="AddAuthorizationHeaderParameterOperationFilter">
//Developed by Amar Singh
//<copyright/>

namespace ASB.WebAPI.App_Start
{
    using Swashbuckle.Swagger;
    using System.Web.Http.Description;
    /// <summary>
    /// Authenicate the header value by parameter
    /// </summary>
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "AuthToken",
                    @in = "header",
                    description = "Access Token : ASB",
                    required = true,
                    type = "string"
                }
                );
            }
        }
    }
}