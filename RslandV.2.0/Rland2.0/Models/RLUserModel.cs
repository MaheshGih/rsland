using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Rland2._0.Models
{
    public class RLUserModel
    {
        public RLUserModel()
        {
            notificationModel = new NotificationModel();
        }
        public int Id { get; set; }

        //[Required(ErrorMessage = " ")]
        //[StringLength(1000, MinimumLength = 6, ErrorMessage = "Login ID must be atleast 6 characters")]
        //[Remote("UserNameExists", "Home", HttpMethod = "POST", ErrorMessage = "User ID already exists")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [RegularExpression(@"(?=^.{6})(?=.*[^\w\d]).*$", ErrorMessage = "Password should contain atleast 6 characters with one special character")]
        public string NewPassword { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "New Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        public string Status { get; set; }

        public NotificationModel notificationModel { get; set; }

        public int? NotificationId { get; set; }

        public string Type { get; set; }

        public bool IsSendNotification { get; set; }

        public int LoggedInUserPriority { get; set; }

        public bool IsRemember { get; set; }



    }
}