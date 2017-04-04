﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ResLandEntities : DbContext
    {
        public ResLandEntities()
            : base("name=ResLandEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ACTIVITY> ACTIVITies { get; set; }
        public DbSet<ACTIVITY_LKUP> ACTIVITY_LKUP { get; set; }
        public DbSet<ADDRESS> ADDRESSes { get; set; }
        public DbSet<ARTIFACT> ARTIFACTs { get; set; }
        public DbSet<ARTIFACT_TYPE_LKUP> ARTIFACT_TYPE_LKUP { get; set; }
        public DbSet<CANDIDATE> CANDIDATEs { get; set; }
        public DbSet<CANDIDATE_SOCIALMEDIA_SELECTED_URLS> CANDIDATE_SOCIALMEDIA_SELECTED_URLS { get; set; }
        public DbSet<CATEGORY_LKUP> CATEGORY_LKUP { get; set; }
        public DbSet<CLIENT> CLIENTs { get; set; }
        public DbSet<COMPANY> COMPANies { get; set; }
        public DbSet<COMPANY_CLIENTS> COMPANY_CLIENTS { get; set; }
        public DbSet<COMPANY_HOLIDAY> COMPANY_HOLIDAY { get; set; }
        public DbSet<CONTACT_MODE_LKUP> CONTACT_MODE_LKUP { get; set; }
        public DbSet<CONTRACTOR> CONTRACTORs { get; set; }
        public DbSet<COUNTRY_LKUP> COUNTRY_LKUP { get; set; }
        public DbSet<DURATION_LKUP> DURATION_LKUP { get; set; }
        public DbSet<EMAIL_LOG> EMAIL_LOG { get; set; }
        public DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public DbSet<ETHINIC_LKUP> ETHINIC_LKUP { get; set; }
        public DbSet<FEATURE_ACCESS> FEATURE_ACCESS { get; set; }
        public DbSet<FEATURE_SCREEN> FEATURE_SCREEN { get; set; }
        public DbSet<FREQUENCY_LKUP> FREQUENCY_LKUP { get; set; }
        public DbSet<HOURS_LOGGED> HOURS_LOGGED { get; set; }
        public DbSet<INVOICE> INVOICEs { get; set; }
        public DbSet<JOB> JOBs { get; set; }
        public DbSet<JOB_APPLICATION> JOB_APPLICATION { get; set; }
        public DbSet<JOB_CANDIDATE> JOB_CANDIDATE { get; set; }
        public DbSet<JOB_POSTING> JOB_POSTING { get; set; }
        public DbSet<JOB_TYPE_LKUP> JOB_TYPE_LKUP { get; set; }
        public DbSet<NOTIFICATION> NOTIFICATIONs { get; set; }
        public DbSet<PACKAGE_FEATURE> PACKAGE_FEATURE { get; set; }
        public DbSet<PAYMENT_PERIOD_LKUP> PAYMENT_PERIOD_LKUP { get; set; }
        public DbSet<PAYMENT_TYPE_LKUP> PAYMENT_TYPE_LKUP { get; set; }
        public DbSet<PERIOD_LKUP> PERIOD_LKUP { get; set; }
        public DbSet<POSTING_SUBMISSION> POSTING_SUBMISSION { get; set; }
        public DbSet<PROCESSING_STATE_LKUP> PROCESSING_STATE_LKUP { get; set; }
        public DbSet<PROJECT> PROJECTs { get; set; }
        public DbSet<PROJECT_RESOURCE> PROJECT_RESOURCE { get; set; }
        public DbSet<QUESTION_LKUP> QUESTION_LKUP { get; set; }
        public DbSet<RESIDENCY_LKUP> RESIDENCY_LKUP { get; set; }
        public DbSet<RESOURCE_PRIVILEGE_LKUP> RESOURCE_PRIVILEGE_LKUP { get; set; }
        public DbSet<RESOURCE_PROFILE> RESOURCE_PROFILE { get; set; }
        public DbSet<RESOURCE_TYPE_LKUP> RESOURCE_TYPE_LKUP { get; set; }
        public DbSet<RL_FEATURE> RL_FEATURE { get; set; }
        public DbSet<RL_LOG> RL_LOG { get; set; }
        public DbSet<RL_USER_LOG_DETAILS> RL_USER_LOG_DETAILS { get; set; }
        public DbSet<RL_USER_LOGIN_ATTEMPT> RL_USER_LOGIN_ATTEMPT { get; set; }
        public DbSet<RL_USER_TRACK_LOGGING> RL_USER_TRACK_LOGGING { get; set; }
        public DbSet<RL_USERS> RL_USERS { get; set; }
        public DbSet<ROLE_LKUP> ROLE_LKUP { get; set; }
        public DbSet<SCHEDULER_EXECUTION_LOG> SCHEDULER_EXECUTION_LOG { get; set; }
        public DbSet<SCHEDULER_FREQUENCY> SCHEDULER_FREQUENCY { get; set; }
        public DbSet<SCHEDULER_TYPE_LKUP> SCHEDULER_TYPE_LKUP { get; set; }
        public DbSet<SCREEN_ACTION> SCREEN_ACTION { get; set; }
        public DbSet<SETTING> SETTINGS { get; set; }
        public DbSet<SIGNATURE> SIGNATUREs { get; set; }
        public DbSet<SKILL> SKILLs { get; set; }
        public DbSet<SKILL_LKUP> SKILL_LKUP { get; set; }
        public DbSet<SMTP_CLIENT> SMTP_CLIENT { get; set; }
        public DbSet<SOCIALMEDIA_LKUP> SOCIALMEDIA_LKUP { get; set; }
        public DbSet<SOURCE_LKUP> SOURCE_LKUP { get; set; }
        public DbSet<STATUS_LKUP> STATUS_LKUP { get; set; }
        public DbSet<SUBMISSION_STATUS> SUBMISSION_STATUS { get; set; }
        public DbSet<SUBSCRIBER> SUBSCRIBERs { get; set; }
        public DbSet<SUBSCRIPTION> SUBSCRIPTIONs { get; set; }
        public DbSet<SUBSCRIPTION_PACKAGE> SUBSCRIPTION_PACKAGE { get; set; }
        public DbSet<SUBSCRIPTION_PACKAGE_PERIOD> SUBSCRIPTION_PACKAGE_PERIOD { get; set; }
        public DbSet<TEMPLATE> TEMPLATEs { get; set; }
        public DbSet<TIMESHEET> TIMESHEETs { get; set; }
        public DbSet<TIMESHEET_LOG> TIMESHEET_LOG { get; set; }
        public DbSet<TIMESHEET_WORKFLOW> TIMESHEET_WORKFLOW { get; set; }
        public DbSet<USER_DETAILS> USER_DETAILS { get; set; }
        public DbSet<USER> USERS { get; set; }
        public DbSet<VENDOR> VENDORs { get; set; }
        public DbSet<WEEK_CALENDER> WEEK_CALENDER { get; set; }
    
        public virtual int SP_ACCTUNLOCKUSER(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACCTUNLOCKUSER", iDParameter);
        }
    
        public virtual int sp_Creatingweeknumbersbasedonyear(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Creatingweeknumbersbasedonyear", yearParameter);
        }
    }
}
