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
    
    public partial class RL_USER_LOGIN_ATTEMPT
    {
        public int ID { get; set; }
        public string USER_ID { get; set; }
        public int LOGIN_ATTEMPT_CNT { get; set; }
        public int MAX_ATTEMPT_CNT { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    }
}