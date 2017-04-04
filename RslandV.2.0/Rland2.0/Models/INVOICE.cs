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
    
    public partial class INVOICE
    {
        public int ID { get; set; }
        public int SUBSCRIPTION_ID { get; set; }
        public int SUBSCR_PKG_ID { get; set; }
        public System.DateTime START_DT { get; set; }
        public System.DateTime END_DT { get; set; }
        public decimal AMT_DUE { get; set; }
        public decimal AMT_PAID { get; set; }
        public decimal AMT_ADJ { get; set; }
        public decimal DISCOUNT_ADJ { get; set; }
        public string DESCR { get; set; }
        public string STAT { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    
        public virtual SUBSCRIPTION SUBSCRIPTION { get; set; }
        public virtual SUBSCRIPTION_PACKAGE SUBSCRIPTION_PACKAGE { get; set; }
    }
}
