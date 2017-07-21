using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Queries
{
    public static class Login
    {
        public static string GetUserHashPassword(string userName)
        {
            return string.Format(@"SELECT password_hash FROM mrbs_users where name = '{0}'", userName);
        }

        public static string GetUser(string userName)
        {
            return string.Format(@"SELECT * FROM mrbs_users where name = '{0}'", userName);
        }
    }
}
