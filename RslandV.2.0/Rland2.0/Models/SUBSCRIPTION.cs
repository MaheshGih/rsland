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
    
    public partial class SUBSCRIPTION
    {
        public SUBSCRIPTION()
        {
            this.INVOICEs = new HashSet<INVOICE>();
        }
    
        public int ID { get; set; }
        public int COMP_ID { get; set; }
        public int SUBSCR_PKG_ID { get; set; }
        public System.DateTime TRIAL_START_DT { get; set; }
        public System.DateTime EFF_FROM { get; set; }
        public System.DateTime EFF_TO { get; set; }
        public Nullable<int> PYMT_NUM { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    
        public virtual COMPANY COMPANY { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual SUBSCRIPTION_PACKAGE SUBSCRIPTION_PACKAGE { get; set; }
    }
}
