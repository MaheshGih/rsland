//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rland2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBMISSION_STATUS
    {
        public int ID { get; set; }
        public int POSTING_SUBMISSION_ID { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> INTERVIEW_DT { get; set; }
        public string INTERVIEW_TIME { get; set; }
        public string INTERVIEWER { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public string LOCATION { get; set; }
        public string COMMENTS { get; set; }
        public Nullable<int> INTERVIEWER_RATING { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    
        public virtual POSTING_SUBMISSION POSTING_SUBMISSION { get; set; }
    }
}