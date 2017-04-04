using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rland2._0.BusinessLogic
{
    public class CommonBinding
    {
        public static string gethtmlContent(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string strReturn = text;
                strReturn = HttpUtility.HtmlDecode(text);
                return strReturn;
            }
            else
                return string.Empty;
        }
    }
}