//<copyright file="LeadResponse">
//Developed by Amar Singh
//</copyright>
namespace ASB.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// LeadResponse
    /// </summary>
    public class LeadResponse
    {
        /// <summary>
        /// leadId  which will be shown as output
        /// </summary>
        public string leadId { get; set; }
        /// <summary>
        /// message  which will be shown as output
        /// </summary>
        public string message { get; set; }
    }
}