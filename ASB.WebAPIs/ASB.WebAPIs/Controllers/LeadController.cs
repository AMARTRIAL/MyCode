//<copyright file="LeadController">
//Developed by Amar Singh
//</copyright>
namespace ASB.WebAPIs.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Swashbuckle.Swagger.Annotations;
    using Microsoft.Xrm.Sdk;
    using System.Configuration;
    using System.ServiceModel;
    using log4net;
    using ASB.WebAPIs.Utility;
    using ASB.WebAPI.Models;

    /// <summary>
    /// controller
    /// </summary>
    [RoutePrefix("api")]
    public class LeadController : ApiController
    {
        public static readonly ILog logger = LogManager.GetLogger("LogWebApiDetail");
        string crmUrl = ConfigurationManager.AppSettings["crmURL"].ToString();
        IOrganizationService orgService;
        /// <summary>
        /// Create Lead
        /// </summary>
        /// <param name="leadInfo">Contains customer basic info  </param>
        /// <returns></returns>
        [Route("lead")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(LeadResponse))]
        [SwaggerResponse(HttpStatusCode.Conflict, Type = typeof(MessageOutput))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(MessageOutput))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(MessageOutput))]

        [HttpPost]
        public HttpResponseMessage Post([FromBody] LeadRequest leadInfo)
        {
            try {
                Helper helper = new Helper();
                orgService = helper.ConnectCRM(crmUrl, logger);
                if (helper.IsValidRequestAuthentication()){
                    logger.Info("Lead request started");
                    if (ModelState.IsValid)
                    {
                        var response = helper.CreateLead(orgService, logger, leadInfo);
                        LeadResponse leadRes = new LeadResponse
                        {
                            leadId = response.leadId.ToString(),
                            message = response.message.ToString()
                        };
                        logger.Info("200 : LeadId = " + response.leadId.ToString());
                        return Request.CreateResponse(HttpStatusCode.OK, leadRes);

                    }
                    else
                    {
                        logger.Info("400 : Invalid Request " + ModelState.Values);
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }
                }
                else {
                    logger.Info("401 : Authentication Failed!");
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new MessageOutput { message = "Caller was not authenticated!" });
                }
            }
            catch (FaultException<IOrganizationService> ex)
            {
                logger.Info("Lead was not created " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new MessageOutput { message = "Lead was not created. Please Try again!" + ex.Message });
            }
            catch (Exception ex)
            {
                logger.Info("Lead was not created " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new MessageOutput { message = "Lead was not created. Please Try again!" + ex.Message });
            }
        }
    }
}
