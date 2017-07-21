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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static string UnixTimeStamp(DateTime dateTime)
        {
            var dateTime1 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.TimeOfDay.Hours, dateTime.TimeOfDay.Minutes, 0, DateTimeKind.Local);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double unixDateTime = (dateTime1.ToUniversalTime() - epoch).TotalSeconds;

            return unixDateTime.ToString().Substring(0, 10);
        }
    }
}
