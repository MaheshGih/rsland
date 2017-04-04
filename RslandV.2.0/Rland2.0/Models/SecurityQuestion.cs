using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Rland2._0.Models
{
    public class SecurityQuestion 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question is required")]
        [Remote("ChkQuestionDoesNotExist", "GlobalConfig", HttpMethod = "POST", ErrorMessage = "Question already exists")]
        public string Question { get; set; }

    }
}