using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rland2._0.Models
{
    public class NotificationModel
    {
        [Required(ErrorMessage = " ")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Email is not in valid format")]
        public string PrimaryEmail { get; set; }
    }
}