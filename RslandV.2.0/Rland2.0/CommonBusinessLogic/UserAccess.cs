using System;
using Rland2._0.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rland2._0.BusinessLogic;
using Rland2._0.AdminBusinessLogic;
using System.Web.Security;

namespace Rland2._0.CommonBusinessLogic
{
    public class UserAccess
    {
        public bool ChangePassword(HomeModel homemodel)
        {

            bool pwdValidation = false;
            RL_Constants rlConstants = new RL_Constants();
         

            if (homemodel.rluserModel.NewPassword != null &&
                homemodel.rluserModel.NewPassword == homemodel.rluserModel.ConfirmPassword)
            {

                BL_RLUsers blRLusers = new BL_RLUsers();
                blRLusers.ChangePassword(homemodel.rluserModel);

                var rlUser = blRLusers.GetRLUser(homemodel.rluserModel.Id);
                FormsAuthentication.SetAuthCookie(rlUser.UserName, true);
                HttpContext.Current.Session["USER"] = rlUser;
                HttpContext.Current.Session["USER_ID"] = rlUser.UserName;
                HttpContext.Current.Session["RES_TYPE"] = rlUser.Type;
                HttpContext.Current.Session["RL_ID"] = rlUser.Id;
                pwdValidation = true;   /// Ask Questions

            }

            return pwdValidation;
        }

    }
}