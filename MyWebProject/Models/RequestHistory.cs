//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWebProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestHistory
    {
        public int RequestHistory_ID { get; set; }
        public int Request_ID { get; set; }
        public string RequestHistoryStatus { get; set; }
    
        public virtual DetailsOfRequest DetailsOfRequest { get; set; }
    }

}