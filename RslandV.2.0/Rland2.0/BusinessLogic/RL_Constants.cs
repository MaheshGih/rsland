using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.BusinessLogic
{
    public class RL_Constants
    {

        #region Constants - Feature Access
        public static Dictionary<string, bool> isAuthenticated { get; set; }

        #endregion


        public string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }
        #region Track Actions - Constants
        #region Constants- Tracking User When Logged In
        public static string USER_LOGGED_PRV_STATE = "LOGGED_IN";
        public static string USER_LOGGED_ACTION = "TRACKED_USER";
        public static string USER_LOGGED_NOTES = "Tracking Location is pending";
        #endregion


        #region Constants - Tracking User When Entered into Dash board
        public static string USER_DASH_BOARD_PRV_STATE = "LOGGED_TO_DASHBOARD";
        public static string USER_DASH_BOARD_ACTION = "ENTERED_DASHBOARD";
        public static string USER_DASH_BOARD_NOTES = "Entered into Dashboard";
        public static string USER_DASH_BOARD_NEXT = "CLICKED_NEXT_WEEK";
        public static string USER_DASH_BOARD_PREV = "CLICKED_PREV_WEEK";

        #endregion

        #region Constants- Tracking User When Entered in Employee Screen
        public static string USER_EMPLOYEE_ENTER_PREV_STATE = "USER_CLICK _EMPLOYEE";
        public static string USER_EMPLOYEE_ENTER_ACTION = "USER_ENTERED_EMPLOYEE";
        public static string USER_EMPLOYEE_ENTER_NOTES = "User Entered into Employee Screen";

        public static string USER_EMPLOYEE_ADD_PREV_STATE = "USER_CLICKED_ADDEMPLOYEE";
        public static string USER_EMPLOYEE_ADD_ACTION = "USER_CLICKED_SAVE";
        public static string USER_EMPLOYEE_ADD_NOTES = "User Saved a Employee";

        public static string USER_EMPLOYEE_EDIT_PREV_STATE = "USER_CLICKED_EDIT";
        public static string USER_EMPLOYEE_EDIT_ACTION = "USER_UPDATING_DETALS";
        public static string USER_EMPLOYEE_EDIT_NOTES = "User clicked on Edit Button";

        public static string USER_EMPLOYEE_DEL_PREV_STATE = "USER_CLICKED_DELETE";
        public static string USER_EMPLOYEE_DEL_ACTION = "EMPLOYEE_DELETED";
        public static string USER_EMPLOYEE_DEL_NOTES = "User Deleted an Employee";
        #endregion

        #region Constants- Tracking User When Entered in CONTRACTOR Screen
        public static string USER_CONTRACTOR_ENTER_PREV_STATE = "USER_CLICK _CONTRACTOR";
        public static string USER_CONTRACTOR_ENTER_ACTION = "USER_ENTERED_CONTRACTOR";
        public static string USER_CONTRACTOR_ENTER_NOTES = "User Entered into CONTRACTOR Screen";

        public static string USER_CONTRACTOR_ADD_PREV_STATE = "USER_CLICKED_ADDCONTRACTOR";
        public static string USER_CONTRACTOR_ADD_ACTION = "USER_CLICKED_SAVE";
        public static string USER_CONTRACTOR_ADD_NOTES = "User Saved a CONTRACTOR";

        public static string USER_CONTRACTOR_EDIT_PREV_STATE = "USER_CLICKED_EDIT";
        public static string USER_CONTRACTOR_EDIT_ACTION = "USER_UPDATING_DETALS";
        public static string USER_CONTRACTOR_EDIT_NOTES = "User clicked on Edit Button";

        public static string USER_CONTRACTOR_DEL_PREV_STATE = "USER_CLICKED_DELETE";
        public static string USER_CONTRACTOR_DEL_ACTION = "CONTRACTOR_DELETED";
        public static string USER_CONTRACTOR_DEL_NOTES = "User Deleted an CONTRACTOR";
        #endregion


        #region Constants- Tracking User When Entered in CLIENT Screen
        public static string USER_CLIENT_ENTER_PREV_STATE = "USER_CLICK _CLIENT";
        public static string USER_CLIENT_ENTER_ACTION = "USER_ENTERED_CLIENT";
        public static string USER_CLIENT_ENTER_NOTES = "User Entered into CLIENT Screen";

        public static string USER_CLIENT_ADD_PREV_STATE = "USER_CLICKED_ADDCLIENT";
        public static string USER_CLIENT_ADD_ACTION = "USER_CLICKED_SAVE";
        public static string USER_CLIENT_ADD_NOTES = "User Saved a CLIENT";

        public static string USER_CLIENT_EDIT_PREV_STATE = "USER_CLICKED_EDIT";
        public static string USER_CLIENT_EDIT_ACTION = "USER_UPDATING_DETALS";
        public static string USER_CLIENT_EDIT_NOTES = "User clicked on Edit Button";

        public static string USER_CLIENT_DEL_PREV_STATE = "USER_CLICKED_DELETE";
        public static string USER_CLIENT_DEL_ACTION = "CLIENT_DELETED";
        public static string USER_CLIENT_DEL_NOTES = "User Deleted an CLIENT";
        #endregion

        #region Constants- Tracking User When Entered into Timesheet Screen

        public static string USER_TIMESHEET_ENTER_PREV_STATE = "USER_CLICK _TIMESHEET";
        public static string USER_TIMESHEET_ENTER_ACTION = "USER_ENTERED_TIMESHEET";
        public static string USER_TIMESHEET_ENTER_NOTES = "User Entered into TIMESHEET Screen";


        public static string USER_TIMESHEET_SELECTMONTH_PREV_STATE = "USER_ENTERED_TIMESHEET";
        public static string USER_TIMESHEET_SELECTMONTH_ACTION = "USR_SELECTMONTH_TIMESHEET";
        public static string USER_TIMESHEET_SELECTMONTH_NOTES = "User Selected a Month/Year in TIMESHEET Screen";

        public static string USER_TIMESHEET_CLICKDETAILS_PREV_STATE = "USER_SELECT_EMPLOYEEORCONTRACTOR";
        public static string USER_TIMESHEET_CLICKDETAILS_ACTION = "USER_VIEW_DETAILS";
        public static string USER_TIMESHEET_CLICKDETAILS_NOTES = "User Selected a Employee or Contractor and View Details";

        public static string USER_TIMESHEET_APPRVLSTATUS_PREV_STATE = "USER_VIEW_DETAILS";
        public static string USER_TIMESHEET_APPRVLSTATUS_ACTION = "USER_APPROVED_EMPLOYEE";
        public static string USER_TIMESHEET_APPRVLSTATUS_NOTES = "User Approved Employee Timesheet";

        public static string USER_TIMESHEET_REJECTSTATUS_PREV_STATE = "USER_SELECT_EMPLOYEEORCONTRACTOR";
        public static string USER_TIMESHEET_REJECTSTATUS_ACTION = "USER_REJECTED_EMPLOYEE";
        public static string USER_TIMESHEET_REJECTSTATUS_NOTES = "User Rejected Employee Timesheet";

        public static string USER_TIMESHEET_ADDTIMESHEET_PREV_STATE = "USER_VIEWED_NOT_ENTERED";
        public static string USER_TIMESHEET_ADDTIMESHEET_ACTION = "USER_ADDED_TIMESHEET";
        public static string USER_TIMESHEET_ADDTIMESHEET_NOTES = "User Seen Not Entered Timesheet and Added It";
        #endregion

        #region Constants-Tracking User When Entered into Project Screen

        public static string USER_PROJECT_ENTER_PREV_STATE = "USER_CLICK _PROJECT";
        public static string USER_PROJECT_ENTER_ACTION = "USER_ENTERED_PROJECT";
        public static string USER_PROJECT_ENTER_NOTES = "User Entered into PROJECT Screen";

        public static string USER_PROJECT_ADD_PREV_STATE = "USER_CLICKED_ADDPROJECT";
        public static string USER_PROJECT_ADD_ACTION = "USER_CLICKED_SAVE";
        public static string USER_PROJECT_ADD_NOTES = "User Saved a PROJECT";

        public static string USER_PROJECT_EDIT_PREV_STATE = "USER_CLICKED_EDIT";
        public static string USER_PROJECT_EDIT_ACTION = "USER_UPDATING_DETALS";
        public static string USER_PROJECT_EDIT_NOTES = "User clicked on Edit Button";

        public static string USER_PROJECT_DEL_PREV_STATE = "USER_CLICKED_DELETE";
        public static string USER_PROJECT_DEL_ACTION = "PROJECT_DELETED";
        public static string USER_PROJECT_DEL_NOTES = "User Deleted an PROJECT";

        #endregion


        #region Constant- When user Logged Out.
        public static string USER_LOGOUT_PREV_STATE = "SOME_ACTION";
        public static string USER_LOGOUT_ACTION = "USER_LOGGEDOUT";
        public static string USER_LOGOUT_NOTES = "We cannot Expect what will be Previous Action";
        #endregion
        #endregion

    }
}