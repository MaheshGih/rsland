using Rland2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.AdminBusinessLogic
{
    public class BL_Base
    {

        public RLUserModel RlUser { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Priority { get; set; }
        public int LoggedInUserPriority { get; set; }

        /// <summary>
        /// Constructor to set the username and User ID from session
        ///Created By:Sandip.Reddy
        /// Created On:03-04-2014
        /// ModifiedBy:
        /// ModifiedOn:
        /// Reason for Modify:
        /// </summary>
        public BL_Base()
        {
            RlUser = HttpContext.Current.Session["USER"] as RLUserModel;
            if (RlUser != null)
            {
                UserId = RlUser.Id;
                UserName = RlUser.UserName;
                LoggedInUserPriority = RlUser.LoggedInUserPriority;
            }
            //Dont know why user is not in session sometimes
            else
            {
                if (HttpContext.Current.Session["USER_ID"] != null)
                {
                    UserName = HttpContext.Current.Session["USER_ID"].ToString();
                }
                else
                {
                    UserId = 0;
                    UserName = "rland";
                }
            }
        }
    }
}
