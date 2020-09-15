using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebProject.Models
{
    public class ApprovalMatrix
    {
        public string PreparedBy { get; set; }
        public string ConcurredBy { get; set; }
        public string ApprovedBy { get; set; }
    }
}