using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            rluserModel = new RLUserModel();
        }

      

        public RLUserModel rluserModel { get; set; }

        public NotificationModel notificationModel { get; set; }

        public QuestionAnswersModel questionAnswersModel { get; set; }

        public SecurityQuestion securityQuestion { get; set; }
    }
}