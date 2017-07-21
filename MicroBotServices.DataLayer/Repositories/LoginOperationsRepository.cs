using MicroBotServices.DataLayer.Common;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.Models.DomainModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Repositories
{
    public class LoginOperationsRepository : Repository, ILoginOperationsRepository 
    {
        public User GetUserDeatils(string userName)
        {
            return Get<User>(Queries.Login.GetUser(userName), GetUserAction, new User());
        }

        public string GetHashPasswordByUserName(string userName)
        {
            return GetStringResult(Queries.Login.GetUserHashPassword(userName));
        }

        #region Helper Methods

        static Action<MySqlDataReader, User> GetUserAction
        {
            get
            {
                return new Action<MySqlDataReader, User>((dr, user) =>
                {
                    while (dr.Read())
                    {
                        user.Id = dr.GetInt32("id");
                        user.Level = dr.GetInt32("level");
                        user.Name = dr.GetString("name");
                        user.Email = dr.GetString("email");
                    }
                });
            }
        }

        #endregion
    }
}
