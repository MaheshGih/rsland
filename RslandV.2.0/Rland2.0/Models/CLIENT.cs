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
    
    public partial class CLIENT
    {
        public CLIENT()
        {
            this.COMPANY_CLIENTS = new HashSet<COMPANY_CLIENTS>();
            this.CONTRACTORs = new HashSet<CONTRACTOR>();
            this.EMPLOYEEs = new HashSet<EMPLOYEE>();
        }
    
        public int ID { get; set; }
        public string USER_ID { get; set; }
        public string NAME { get; set; }
        public int ADDR_ID { get; set; }
        public string PHONE_NUM1 { get; set; }
        public string PHONE_NUM2 { get; set; }
        public string FAX_NUM { get; set; }
        public string EMAIL_ID { get; set; }
        public int COMP_ID { get; set; }
        public string EIN { get; set; }
        public string DOMAIN { get; set; }
        public string STAT { get; set; }
        public string WEBSITE { get; set; }
        public string KEY_TECHNOLOGIES { get; set; }
        public string NOTES { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    
        public virtual ICollection<COMPANY_CLIENTS> COMPANY_CLIENTS { get; set; }
        public virtual ICollection<CONTRACTOR> CONTRACTORs { get; set; }
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
    }
}
