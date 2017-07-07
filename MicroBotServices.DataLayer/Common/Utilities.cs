using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Common
{
    public static class Utilities
    {
        public static string ConnectionString
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}{5}{6}",
                    "SERVER=",
                    ConfigurationManager.AppSettings["mySqlServer"],
                    ";DATABASE=" + ConfigurationManager.AppSettings["mySqlDb"],
                    ";UID=",
                    ConfigurationManager.AppSettings["userId"],
                    ";PASSWORD=",
                    ConfigurationManager.AppSettings["password"]) + ";";
            }
        }
    }
}
