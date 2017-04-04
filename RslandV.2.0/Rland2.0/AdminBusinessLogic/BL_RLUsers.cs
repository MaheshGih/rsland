using Rland2._0.BusinessLogic;
using Rland2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Rland2._0.AdminBusinessLogic
{
    public class BL_RLUsers
    {

        private ResLandEntities context;
        public BL_RLUsers()
        {
            context = new ResLandEntities();
        }
        public void AddRLUser(HomeModel homeModel)
        {
            String html = "";
            
            // string USER_ID = HttpContext.Current.Session["USER_ID"].ToString();
            // string RES_TYPE = HttpContext.Current.Session["RES_TYPE"].ToString();
            //string currentsessionid= HttpContext.Current.Session["SESSION_ID"].ToString();
            string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            //var serverAddress = "localhost:58757";
            //var url = "http://" + serverAddress + "/Admin";
           homeModel.rluserModel.Password = GenerateRandomWord(8);
            
            Email email = new Email();
            string type;
            if (homeModel.rluserModel == null)
            {

                type = "USERREGISTRATION";
                html = email.GetEmailBasedOnTemplateType(type);
                html = html.Replace("[USERID]", homeModel.rluserModel.UserName);
                html = html.Replace("[UserID]", homeModel.rluserModel.UserName);
                
            }
            else
            {
                type = "SUBSCRIPTION";
                html = email.GetEmailBasedOnTemplateType(type);
                html = html.Replace("[USERID]", homeModel.rluserModel.UserName);
                html = html.Replace("[ContactEmailID]", homeModel.notificationModel.PrimaryEmail);

            }

            var emailDetails = email.GetEmailDetails(type);
            email.sendFrom = emailDetails.USER_ID;
            email.sendSubject = emailDetails.SUBJECT;
            email.sendTo = homeModel.notificationModel.PrimaryEmail;
            email.sendBody = html;


            // Add User to database
            this.AddUser(homeModel.rluserModel, html);

            //Sending email
            Task.Run(() =>
            {
                email.SendMail(type, homeModel.rluserModel.UserName, email.sendFrom, email.sendTo, "ADMIN", homeModel.rluserModel.UserName, type, null);
            });

        }

        private void AddUser(RLUserModel user, String html)
        {
            var key = GenerateRandomWord(8);
            var concatenated = key + user.Password;
            Encryption encrytion = new Encryption();
           
            // If notification is Not Empty 
            if (!user.NotificationId.HasValue)
            {
                var notification = new NOTIFICATION()
                {
                   
                    IS_DELETED = "N",
                    CR_BY = user.UserName,
                    PRI_EMAIL_ID = user.notificationModel.PrimaryEmail,
                    DT_CR = DateTime.Now

                };
                context.NOTIFICATIONs.Add(notification);
                context.SaveChanges();
                user.NotificationId = notification.ID;
            }


            var rluser = new RL_USERS()
            {
                USER_ID = user.UserName,
                RES_TYPE = user.Type,
                NAME = user.UserName,
                STAT = "INACTIVE",
                PWD = encrytion.Encrypt(concatenated),
                NOTIFICATION_ID = user.NotificationId,
                USER_ACTIVATED = "N",
                IS_DELETED = "N",
                CR_BY = user.UserName,
                DT_CR = DateTime.Now

            };

            context.RL_USERS.Add(rluser);
            context.SaveChanges();
            user.Id = rluser.ID;
            user.Password = rluser.PWD;
           

        }

        public RLUserModel ValidateRLLogin(RLUserModel user)
        {
            RL_Constants rlConstants = new RL_Constants();
            var dbUser = context.RL_USERS.Where(x => (x.USER_ID == user.UserName && (x.RES_TYPE == "SUBSCRIBER"))).FirstOrDefault();
            if (dbUser == null)
            {
                return null;
            }
            var retUser = ConvertToModel(dbUser);

            if (retUser.Password.EndsWith(user.Password))
            {
                SessionIDManager manager = new SessionIDManager();
                HttpContext.Current.Session["SESSION_ID"] = manager.CreateSessionID(HttpContext.Current);
                return retUser;

            }
            return null;

        }

        private RLUserModel ConvertToModel(RL_USERS dbUser)
        {
            Encryption encryption = new Encryption();

            var rluser = new RLUserModel()
            {
                Id = dbUser.ID,
                UserName = dbUser.USER_ID,
                Type = dbUser.RES_TYPE,
                Status = dbUser.STAT,
                Password = encryption.Decrypt(dbUser.PWD),
                NotificationId = dbUser.NOTIFICATION_ID,
               
            };


            return rluser;
        }

        public RLUserModel GetRLUser(int userid)
        {

            var user = context.RL_USERS.FirstOrDefault(x => x.ID == userid);
            var retUser = ConvertToModel(user);
            if (user.NOTIFICATION_ID.HasValue)
            {
                var notification = context.NOTIFICATIONs.FirstOrDefault(x => x.ID == user.NOTIFICATION_ID.Value);
                var notificationModel = new NotificationModel();
                notificationModel.PrimaryEmail = notification.PRI_EMAIL_ID;
                retUser.notificationModel = notificationModel;
            }
            return retUser;

        }

        public void ChangePassword(RLUserModel rlUserModel)
        {
            //string USER_ID = HttpContext.Current.Session["USER_ID"].ToString();
            string emailId = null;

            var dbUser = context.RL_USERS.Where(x => x.ID == rlUserModel.Id).FirstOrDefault();

       
                var notification = context.NOTIFICATIONs.Where(x => x.ID == dbUser.NOTIFICATION_ID).FirstOrDefault();
                if (notification != null)
                {
                    emailId = notification.PRI_EMAIL_ID;
                }
            


            Encryption encrytion = new Encryption();
            var key = GenerateRandomWord(8);

            var concatenated = key + rlUserModel.NewPassword;

            dbUser.PWD = encrytion.Encrypt(concatenated);
            dbUser.STAT = "ACTIVE";
            context.SaveChanges();
            //string restype = HttpContext.Current.Session["RES_TYPE"].ToString();
            string currentsessionid = HttpContext.Current.Session["SESSION_ID"].ToString();

            if (!string.IsNullOrEmpty(emailId))
            {

                Task.Run(() =>
                {
                    String html = "";
                    Email email = new Email();

                    string type = "CHANGEPASSWORD";
                    html = email.GetEmailBasedOnTemplateType(type);
                    html = html.Replace("[First_Name]", dbUser.USER_ID);
                    html = html.Replace("[UserID]", dbUser.USER_ID);
                    html = html.Replace("[Password]", rlUserModel.NewPassword);

                    var emailDetails = email.GetEmailDetails("CHANGEPASSWORD");
                    email.sendFrom = emailDetails.USER_ID;
                    email.sendSubject = emailDetails.SUBJECT;

                    email.sendTo = emailId;
                    email.sendBody = html;
                    email.SendMail("CHANGEPASSWORD", dbUser.USER_ID, email.sendFrom, email.sendTo, rlUserModel.Type, dbUser.USER_ID, type, currentsessionid);
                });

            }
        }
        public static string GenerateRandomWord(int RequestedWordLength)  //If you are always going to want 8 characters then there is no need to pass a length argument
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789-";
            Random randNum = new Random((int)DateTime.Now.Ticks);  //Don't forget to seed your random, or else it won't really be random
            char[] chars = new char[RequestedWordLength];
            //again, no need to pass this a variable if you always want 8

            for (int i = 0; i < RequestedWordLength; i++)
            {
                chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
                //No need to over complicate this, passing an integer value to Random. Next will "Return a nonnegative random number less than the specified maximum."
            }
            return new string(chars);
        }
    }
}