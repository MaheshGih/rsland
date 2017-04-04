using Rland2._0.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Rland2._0.BusinessLogic
{
    public class Email
    {
        ResLandEntities reslandentity = new ResLandEntities();
        public string sendTo = string.Empty;
        public string sendFrom = string.Empty;
        public string sendSubject = string.Empty;
        public string onlineResLibUserName = string.Empty;
        public string onlineResLibPassword = string.Empty;
        public string sendBody = string.Empty;
        public string MessageTemplate = string.Empty;
        public string sendCC = string.Empty;
        public string sendBCC = string.Empty;
        public string sendCertPath = string.Empty;
        public MailMessage usermailMessage = null;
        public ArrayList toAddress = null;
        public ArrayList ccAddress = null;



        public void SendMail(string mailFor, string CreatedBy, string Emailfrom, string Emailto, string type, string replacedtext, string templatetype, string sessionid = null)
        {

            try
            {
                // Send email
                dispatchMail(mailFor);

                // On Success
                logEmail("SUCCESS", mailFor, CreatedBy, Emailfrom, Emailto, type, replacedtext, templatetype, sessionid);

            }

            catch (Exception err)
            {
                // On Failure/Exception
                logEmail("FAILURE", mailFor, CreatedBy, Emailfrom, Emailto, type, replacedtext, templatetype, sessionid);

                throw err;
            }
        }

        private void logEmail(string status, string mailFor, string CreatedBy, string Emailfrom, string Emailto, string type, string replacedtext, string templatetype, string sessionid = null)
        {

            // Log Email
            EMAIL_LOG emlog = new EMAIL_LOG();
            emlog.CR_BY = CreatedBy;
            emlog.EMAIL_TO = Emailto;
            emlog.EMAIL_FROM = Emailfrom;
            emlog.DT_CR = DateTime.Now;
            emlog.TEMPLATETYPE = templatetype;
            emlog.SESSION_ID = sessionid;
            emlog.REPLACED_TEXT = replacedtext;
            emlog.TYPE = type;

            emlog.IS_DELETED = "N";
            if (status == "SUCCESS")
            {
                emlog.STATUS = "SUCCESS";
            }
            else
            {
                emlog.STATUS = "FAILURE";
            }

            reslandentity.EMAIL_LOG.Add(emlog);
            reslandentity.SaveChanges();

        }

        public void dispatchMail(string type)
        {


            MailMessage mailMessage = null;
            try
            {
                MailAddress From = new MailAddress(sendFrom);
                MailAddress SendTo = new MailAddress(sendTo);
                mailMessage = new MailMessage(From, SendTo);
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = sendSubject;
                mailMessage.Body = sendBody;

                if (!string.IsNullOrEmpty(sendBCC))
                {
                    if (sendBCC.Contains(";"))
                    {
                        string[] strMails = sendBCC.Split(';');
                        foreach (string s in strMails)
                        {
                            mailMessage.Bcc.Add(s);
                        }
                    }
                    else
                    {
                        mailMessage.Bcc.Add(sendBCC);
                    }
                }
                if (!string.IsNullOrEmpty(sendCC))
                {
                    if (sendCC.Contains(";"))
                    {
                        string[] strMails = sendCC.Split(';');
                        foreach (string s in strMails)
                        {
                            mailMessage.CC.Add(s);
                        }
                    }
                    else
                        mailMessage.CC.Add(sendCC);

                }


                if (ConfigurationManager.AppSettings["MailTest"].ToString().ToLower().Equals("n"))
                {
                    var smtpSettings = reslandentity.SETTINGS.FirstOrDefault(x => x.STAT == "ACTIVE");
                    var smtpmessagetype = reslandentity.TEMPLATEs.Where(x => x.TYPE == type).FirstOrDefault();
                    SmtpClient smtp = new SmtpClient(smtpSettings.SMTP_CLIENT);
                    smtp.Port = smtpSettings.SMTP_PORT;
                    smtp.EnableSsl = smtpSettings.ENABLE_SSL;
                    smtp.UseDefaultCredentials = Convert.ToBoolean(smtpSettings.USE_DEFAULT_CREDENTIALS);
                    smtp.Credentials = new System.Net.NetworkCredential(smtpmessagetype.USER_ID, smtpmessagetype.PWD);

                    smtp.Send(mailMessage);
                    //Added By Pradeep
                }
                else
                {
                    #region For Local
                    SmtpClient SmtpServer = new SmtpClient("localhost");
                    SmtpServer.UseDefaultCredentials = true;
                    SmtpServer.Port = 25;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    SmtpServer.PickupDirectoryLocation = ConfigurationManager.AppSettings["MailPath"].ToString();
                    SmtpServer.Send(mailMessage);
                    #endregion
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public String GetEmailBasedOnTemplateType(string type)
        {

            String html = "";

            TEMPLATE Emailtemp = reslandentity.TEMPLATEs.Where(t => t.TYPE == type && t.IS_DELETED == "N").SingleOrDefault();
            if (Emailtemp != null)
            {
                byte[] myByteArray = Emailtemp.CONTENT.ToArray();
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                string result = enc.GetString(myByteArray);
                html = CommonBinding.gethtmlContent(result);
            }

            return html;
        }

        public TEMPLATE GetEmailDetails(string type)
        {
            return reslandentity.TEMPLATEs.FirstOrDefault(x => x.TYPE == type);
        }

    }
}
