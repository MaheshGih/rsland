using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rland2._0.AdminBusinessLogic;
using Rland2._0.Models;
using Rland2._0.CommonBusinessLogic;
using System.Threading.Tasks;

namespace Rland2._0.BusinessLogic
{
    public class BL_Home: BL_Base
    {

        private ResLandEntities context;
        public BL_Home()
        {
            context = new ResLandEntities();
        }
        public void AddRegister(HomeModel homeModel)
        {

            // Notification
            Notification notification = new Notification();
            int notificationId = notification.AddNotification(homeModel.notificationModel);

            BL_RLUsers rlUsersBl = new BL_RLUsers();

            homeModel.rluserModel.NotificationId = notificationId;
            homeModel.rluserModel.Type = "SUBSCRIBER";

            rlUsersBl.AddRLUser(homeModel);

            Encryption encrypt = new Encryption();

            homeModel.rluserModel.Password = encrypt.Decrypt(homeModel.rluserModel.Password);


            Task.Run(() =>
            {


                Email email = new Email();
                var emailDetails = email.GetEmailDetails("VALIDATEREQUESTFORADMIN");

                string type = "VALIDATEREQUESTFORADMIN";
                string html = email.GetEmailBasedOnTemplateType(type);
                html = html.Replace("[UserName]", homeModel.rluserModel.UserName);
                html = html.Replace("[Password]", homeModel.rluserModel.Password);
                html = html.Replace("[ContactEmailID]", homeModel.notificationModel.PrimaryEmail);
                email.sendFrom = emailDetails.USER_ID;
                email.sendTo = emailDetails.EMAIL_TO;
                email.sendSubject = emailDetails.SUBJECT;
                email.sendBody = html;
                email.SendMail("VALIDATEREQUESTFORADMIN", emailDetails.EMAIL_TO, email.sendFrom, email.sendTo, "NewUSer",homeModel.rluserModel.UserName, type, null);
            });


        }

    }
}