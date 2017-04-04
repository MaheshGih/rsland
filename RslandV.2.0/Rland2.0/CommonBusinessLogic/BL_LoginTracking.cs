using Rland2._0.AdminBusinessLogic;
using Rland2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.CommonBusinessLogic
{
    public class BL_LoginTracking : BL_Base
    {
        private ResLandEntities context;
        public BL_LoginTracking()
        {
            context = new ResLandEntities();
        }


        public List<RL_USER_TRACK_LOGGING> GetLoginTrackings(bool isShowAll)
        {
            if (isShowAll)
            {
                return context.RL_USER_TRACK_LOGGING.OrderByDescending(x => x.DT_CR).Take(100).ToList();
            }
            else
            {

                return context.RL_USER_TRACK_LOGGING.Where(x => !x.LOGOUT_TIME.HasValue).ToList();
            }
        }

        public void TrackLogin()
        {
            string SESSION_ID = HttpContext.Current.Session["SESSION_ID"].ToString();
            RL_USER_TRACK_LOGGING rlUserTrackLogging = new RL_USER_TRACK_LOGGING()
            {
                BROWSER = HttpContext.Current.Request.Browser.Browser + " VER:" + HttpContext.Current.Request.Browser.Version,
                CR_BY = UserName,
                DT_CR = DateTime.Now,
                USER_ID = UserName,
                LOGIN_TIME = DateTime.Now,
                SESSION_ID = SESSION_ID,
                IS_DELETED = "N",
                IP_ADDR = HttpContext.Current.Request.UserHostAddress
            };
            context.RL_USER_TRACK_LOGGING.Add(rlUserTrackLogging);
            context.SaveChanges();
        }

        public void TrackLogout()
        {
            string SESSION_ID = HttpContext.Current.Session["SESSION_ID"].ToString();
            string USER_ID = HttpContext.Current.Session["USER_ID"].ToString();
            var trackLogging = context.RL_USER_TRACK_LOGGING.FirstOrDefault(x => x.SESSION_ID == SESSION_ID && x.USER_ID == USER_ID);
            if (trackLogging != null)
            {
                trackLogging.LOGOUT_TIME = DateTime.Now;
                trackLogging.MOD_BY = UserName;
                trackLogging.HOW_LOGOUT = "USER_LOGOUT";
                trackLogging.DT_MOD = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void AdminForceLogout(int id)
        {
            var trackLogging = context.RL_USER_TRACK_LOGGING.FirstOrDefault(x => x.ID == id);
            if (trackLogging != null)
            {
                trackLogging.LOGOUT_TIME = DateTime.Now;
                trackLogging.MOD_BY = UserName;
                trackLogging.HOW_LOGOUT = "ADMIN_LOGOUT";
                trackLogging.DT_MOD = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}