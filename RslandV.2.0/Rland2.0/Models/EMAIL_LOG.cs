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
    
    public partial class EMAIL_LOG
    {
        public int ID { get; set; }
        public string SESSION_ID { get; set; }
        public string TYPE { get; set; }
        public string EMAIL_TO { get; set; }
        public string EMAIL_FROM { get; set; }
        public string STATUS { get; set; }
        public string TEMPLATETYPE { get; set; }
        public string REPLACED_TEXT { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public byte[] MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
        public string IS_DELETED { get; set; }
    }
}