using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.Models.Common;
using MicroBotServices.Models.ValidationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBotServices.BusinessLayer.Extensions;

namespace MicroBotServices.BusinessLayer.Security
{
    public class LoginOperationsLogic : ILoginOperations
    {
        public EmployeeToken DecodeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Token", Message = "Invalid Token." } }) };
            }
            else
            {
                EmployeeToken employeeTokenInfo = TokenManager.DecodeToken(token);
                if (employeeTokenInfo.VerifyObjectNull(throwEdit: false))
                {
                    throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Token", Message = "Invalid Token." } }) };
                }
                else
                {
                    return employeeTokenInfo;
                }
            }
        }

        public TokenHolder Validate(string userName, string password)
        {
            //if (IdentityHelper.Identity != null && IdentityHelper.Identity.Headers != null)
            //{
                //string userName = IdentityHelper.Identity.Headers["username"];
                //string password = IdentityHelper.Identity.Headers["password"];

                //validate username & password using AD or mysql

                //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || !Utilities.Users.Any(c => c.UserName.Equals(userName) && c.Password.Equals(password)))
                //{
                //    throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "authentication", Message = "Invalid username or password." } }) };
                //}
                //else
                //{
                //    User userInfo = Utilities.Users.FirstOrDefault(c => c.UserName.Equals(userName) && c.Password.Equals(password));
                //    if (userInfo != null)
                //    {
                //        return Security.TokenManager.GenerateToken(new EmployeeToken() { Id = userInfo.EmployeeId, Type = userInfo.Type, UserName = userInfo.UserName, Active = true });
                //    }
                //}
            //}
            return null;
        }

        public bool ValidateToken(string token)
        {
            //if (string.IsNullOrEmpty(token))
            //{
            //    throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Token", Message = "Invalid Token." } }) };
            //}
            //else
            //{
            //    EmployeeToken employeeTokenInfo = TokenManager.DecodeToken(token);
            //    if (employeeTokenInfo.VerifyObjectNull(throwEdit: false) || !Utilities.Users.Any(c => c.EmployeeId.Equals(employeeTokenInfo.Id)))
            //    {
            //        throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Token", Message = "Invalid Token." } }) };
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            return false;
        }
    }
}
