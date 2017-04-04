using Rland2._0.AdminBusinessLogic;
using Rland2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.CommonBusinessLogic
{
    public class Notification: BL_Base
    {

        private ResLandEntities context;
        public Notification()
        {
            context = new ResLandEntities();
        }

        public int AddNotification(NotificationModel Notmodel)
        {
            var notification = new NOTIFICATION()
            {
               
                PRI_EMAIL_ID = Notmodel.PrimaryEmail,
                DT_CR = DateTime.Now,
                IS_DELETED = "N",
                CR_BY = UserName,

            };
            context.NOTIFICATIONs.Add(notification);
            context.SaveChanges();

            return notification.ID;

        }
    }


}
