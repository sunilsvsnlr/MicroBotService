using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MicroBotServices.Models.Common
{
    public static class IdentityHelper
    {
        public static HttpRequest Identity
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    return HttpContext.Current.Request;
                }
                return null;
            }
        }
    }
}
