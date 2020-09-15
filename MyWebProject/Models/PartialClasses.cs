//////////////////////////////////////////
///PROPERTIES NOT CONNECTED TO DATABASE.//
//////////////////////////////////////////

namespace MyWebProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public partial class DetailsOfRequest
    {

        //CoveragePeriod Related
        [NotMapped]
        public DateTime CoveragePeriodStart { get; set; } = DateTime.Now;
        [NotMapped]
        public DateTime CoveragePeriodEnd { get; set; } = DateTime.Now;

        //GamePlan Related
        [NotMapped]
        public HttpPostedFileBase GamePlan1 { get; set; }
        [NotMapped]
        public string GamePlanPath { get; set; }
        [NotMapped]
        public string GamePlanValidation { get; set; }

        //SupportingDocuments Related
        [NotMapped]
        public HttpPostedFileBase SupportingDocuments1 { get; set; }
        [NotMapped]
        public string SupportingDocumentsPath { get; set; }
        [NotMapped]
        public string SupportingDocumentsValidation { get; set; }
    }

    public partial class LoginRequest
    {
        [NotMapped]
        public string LoginError { get; set; }
    }
}