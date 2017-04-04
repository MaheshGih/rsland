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
    
    public partial class JOB
    {
        public JOB()
        {
            this.JOB_POSTING = new HashSet<JOB_POSTING>();
        }
    
        public int ID { get; set; }
        public Nullable<int> COMP_ID { get; set; }
        public string POSTED_BY { get; set; }
        public int POSTED_BY_ID { get; set; }
        public string CONTACT_NAME { get; set; }
        public string CONTACT_PHONE { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string TITLE { get; set; }
        public string DESCR { get; set; }
        public string PREREQUISITES { get; set; }
        public string JOB_TYPE { get; set; }
        public string LOCATION { get; set; }
        public string DURATION { get; set; }
        public Nullable<System.DateTime> POST_DT { get; set; }
        public Nullable<System.DateTime> POST_END_DT { get; set; }
        public int POSITIONS_CNT { get; set; }
        public string CATEGORY { get; set; }
        public string MAX_RATE { get; set; }
        public string MIN_RATE { get; set; }
        public string STAT { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
        public Nullable<int> SKILL_ID { get; set; }
        public string PERKS { get; set; }
        public string JOB_ID { get; set; }
        public string SOURCE { get; set; }
        public string SALARY { get; set; }
        public Nullable<bool> HOT { get; set; }
        public Nullable<bool> PUBLISH { get; set; }
        public Nullable<int> CLIENT_ID { get; set; }
        public string DEPARTMENT { get; set; }
        public string RECRUITER { get; set; }
        public string VENDOR_TYPE { get; set; }
    
        public virtual SKILL SKILL { get; set; }
        public virtual ICollection<JOB_POSTING> JOB_POSTING { get; set; }
    }
}
