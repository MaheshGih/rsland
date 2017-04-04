using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rland2._0.Models
{
    public class QuestionAnswersModel
    { 
       
        public SelectList QuestionsSelectList { get; set; }
        [Required]
        public int Question { get; set; }
        [Required]
        public string Answer { get; set; }
        
      
    }
}