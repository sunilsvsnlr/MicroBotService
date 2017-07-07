using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.BusinessLayer.Extensions;
using MicroBotServices.BusinessLayer.Security;
using MicroBotServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MicroBotServices.WebAPI.Filters
{
    public sealed class MicroBotAuthorizeAttribute : AuthorizeAttribute
    {
        private ILoginOperations UserLoginServices = null;
        public MicroBotAuthorizeAttribute()
        {
            UserLoginServices = new LoginOperationsLogic();
        }

        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            object tempRoles = null;
            List<string> lstRoles = new List<string>();
            var identity = ParseAuthorizationHeader(actionContext);

            if (identity == null)
            {
                return false;
            }

            if (!OnAuthorizeUser(identity.Name, actionContext))
            {
                return false;
            }

            List<Claim> lstClaims = new List<Claim>();
            if (actionContext.Request.Properties.TryGetValue("Token", out tempRoles))
            {
                EmployeeToken employeeTokenInfo = tempRoles as EmployeeToken;
                lstClaims.Add(new Claim(ClaimTypes.Name, employeeTokenInfo.UserName));
                lstClaims.Add(new Claim(ClaimTypes.UserData, identity.Name));
                lstClaims.Add(new Claim(ClaimTypes.Role, employeeTokenInfo.Type.ToString()));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(lstClaims, "MicroBot");
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            Thread.CurrentPrincipal = HttpContext.Current.User = principal;
            return base.IsAuthorized(actionContext);
        }

        private bool OnAuthorizeUser(string key, HttpActionContext actionContext)
        {
            if (UserLoginServices.ValidateToken(key))
            {
                EmployeeToken employeeTokenInfo = UserLoginServices.DecodeToken(key);
                actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Token", employeeTokenInfo));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Parses the Authorization header and creates user credentials
        /// </summary>
        /// <param name="actionContext"></param>
        private BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            IEnumerable<string> result;
            string key = string.Empty;
            if (actionContext.Request.Headers.TryGetValues("Token", out result))
            {
                key = string.IsNullOrEmpty(result.FirstOrDefault()) ? string.Empty : result.FirstOrDefault();
            }

            if (string.IsNullOrEmpty(key))
                return null;

            return new BasicAuthenticationIdentity(key);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.VerifyObjectNull();
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            actionContext.Response.Content = new StringContent(Convert.ToString("Access Restricted"));
        }
    }
}