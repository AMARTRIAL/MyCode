//<copyright file="LeadRequest">
//Developed by Amar Singh
//</copyright>
namespace ASB.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    public class LeadRequest
    {
        [Required(ErrorMessage ="Topic is Required")]
        public string subject { get; set; }

        [Required(ErrorMessage ="First name is Required")]
        [StringLength(30,MinimumLength =1,ErrorMessage ="First Name should be Min 1 and Max 30 Character")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Last Name should be Min 1 and Max 30 Character")]
        public string lastName { get; set; }

        public string jobTitle { get; set; }

        public string emailAddress { get; set; }
    }
}