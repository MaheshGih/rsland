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
    
    public partial class SCHEDULER_FREQUENCY
    {
        public int ID { get; set; }
        public int COMP_ID { get; set; }
        public string SCHEDULER_TYPE { get; set; }
        public string FREQUENCY_TYPE { get; set; }
        public Nullable<System.TimeSpan> TRIGGER_START_TIME { get; set; }
        public Nullable<int> INTERVAL { get; set; }
        public string INTERVAL_DURATION { get; set; }
        public bool SCHEDULE_SUN { get; set; }
        public bool SCHEDULE_MON { get; set; }
        public bool SCHEDULE_TUE { get; set; }
        public bool SCHEDULE_WED { get; set; }
        public bool SCHEDULE_THU { get; set; }
        public bool SCHEDULE_FRI { get; set; }
        public bool SCHEDULE_SAT { get; set; }
        public string STAT { get; set; }
        public string IS_DELETED { get; set; }
        public string CR_BY { get; set; }
        public Nullable<System.DateTime> DT_CR { get; set; }
        public string MOD_BY { get; set; }
        public Nullable<System.DateTime> DT_MOD { get; set; }
    
        public virtual DURATION_LKUP DURATION_LKUP { get; set; }
        public virtual FREQUENCY_LKUP FREQUENCY_LKUP { get; set; }
        public virtual SCHEDULER_TYPE_LKUP SCHEDULER_TYPE_LKUP { get; set; }
    }
}