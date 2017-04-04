using System.Web.Mvc;
using Rland2._0.Models;
using Rland2._0.BusinessLogic;
using Rland2._0.AdminBusinessLogic;
using System;
using System.Web.Security;
using System.Web;
using Rland2._0.CommonBusinessLogic;
using System.Collections.Generic;

namespace Rland2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.rluserModel = new RLUserModel();
            return View(homeModel);
        }

        public ActionResult ValidateLogin(HomeModel homemodel)
        {
            try
            {
                BL_RLUsers blRLusers = new BL_RLUsers();

                var rlUserModel = new RLUserModel();
                rlUserModel.UserName = homemodel.rluserModel.UserName;
                rlUserModel.Password = homemodel.rluserModel.Password;
             
                var user = blRLusers.ValidateRLLogin(rlUserModel);

                if (user == null)
                {
                    ModelState.AddModelError("Password", "User ID or password you entered is incorrect");
                    return View("Login", homemodel);
                }

                else if (user.Status == "INACTIVE")
                {
                    homemodel.rluserModel.Id = user.Id;
                    homemodel.rluserModel.Type = user.Type;
                   

                    TempData["model"] = homemodel;

                    return RedirectToAction("QuestionAnswers");
                }


                FormsAuthentication.SetAuthCookie(user.UserName, true);
                HttpContext.Session["USER"] = user;
                HttpContext.Session["USER_ID"] = user.UserName;
                HttpContext.Session["RES_TYPE"] = user.Type;
                HttpContext.Session["RL_ID"] = user.Id;


                BL_LoginTracking blLoginTracking = new BL_LoginTracking();
                blLoginTracking.TrackLogin();
                if (homemodel.rluserModel.IsRemember)
                {

                    var ticket = new FormsAuthenticationTicket(homemodel.rluserModel.UserName, true, 525600);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie("loginCookie", encrypted);
                    cookie.Expires = System.DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);

                }
                else
                {
                    if (Request.Cookies["loginCookie"] != null)
                    {
                        var cookie = new HttpCookie("loginCookie")
                        {
                            Expires = DateTime.Now.AddDays(-1)
                        };
                        Response.Cookies.Add(cookie);
                    }
                }
                return RedirectToAction("SubscriberDashBoard","SubscriberDashBoard");
            }

            catch (Exception ex)

            {
                return Json("Failure");
            }
      
        }

        public ActionResult QuestionAnswers()
        {
            try
            {
                BL_Question blQuestion = new BL_Question();
                List<SecurityQuestion> questions = blQuestion.GetQuestions();
                HomeModel homemodel = (HomeModel)TempData["model"];
                homemodel.questionAnswersModel = new QuestionAnswersModel();
                homemodel.questionAnswersModel.QuestionsSelectList = new SelectList(questions, "id", "Question");

                return View("QuestionAnswers", homemodel);
            }
            catch (Exception ex)
            {
                return Json("Failure");
            }
        }

        [HttpPost]
        public ActionResult QuestionAnspwd(HomeModel homemodel)
        {
           
            try
            {
                BL_Question blQuestion = new BL_Question();
                blQuestion.AddSecurityQuestions(homemodel);
                bool pwdValidation = false;
                UserAccess uaccess = new UserAccess();
                pwdValidation = uaccess.ChangePassword(homemodel);

                if (pwdValidation)
                {

                    return RedirectToAction("SubscriberDashBoard", "SubscriberDashBoard");

                }
                return View("QuestionAnswers", homemodel);

            }
            catch (Exception ex)
            {
                return Json("Failure");
            }

        }



        public ActionResult Register()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.rluserModel = new RLUserModel();
            homeModel.notificationModel = new NotificationModel();
            return View(homeModel);
        }

        public ActionResult SaveRegister(HomeModel homeModel)
        {

            BL_Home bl_Home = new BL_Home();
            bl_Home.AddRegister(homeModel);
            return RedirectToAction("Login");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}