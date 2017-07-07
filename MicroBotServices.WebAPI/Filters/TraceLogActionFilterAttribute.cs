using MicroBotServices.WebAPI.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.Filters
{
    /// <summary>
    /// Action filter to do trace logging using NLog.
    /// arguments passed to method will be serialized to JSON.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TraceLogActionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute, System.Web.Http.Filters.IActionFilter
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Override to intercept the input to method and log it using NLog.
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException("actionContext");
            string logStatement = Newtonsoft.Json.JsonConvert.SerializeObject(actionContext.ActionArguments, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new TraceLogContractResolver() });
            Logger.Info(String.Format(CultureInfo.InvariantCulture, "[Request] [{0}] [{1}] {2}", actionContext.Request.Method.Method, actionContext.Request.RequestUri.ToString(), logStatement));
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// Override to intercept the output from method and log it using NLog.
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null) throw new ArgumentNullException("actionExecutedContext");
            // Implementation of logging logic for response from APIs is not finished yet.
            string logStatement = string.Empty;
            if (actionExecutedContext.Response != null && actionExecutedContext.Response.Content != null)
            {
                logStatement = Newtonsoft.Json.JsonConvert.SerializeObject
                    (((System.Net.Http.ObjectContent)(actionExecutedContext.Response.Content)).Value, // Need to decide whether to log just the value or whole content. More testing is required.
                    Newtonsoft.Json.Formatting.None,
                    new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new TraceLogContractResolver() });

                Logger.Info(String.Format(CultureInfo.InvariantCulture, "[Response] [{0}] [{1}] [{2}] {3}", actionExecutedContext.Response.StatusCode.ToString(), actionExecutedContext.Request.Method.Method, actionExecutedContext.Request.RequestUri.ToString(), logStatement));
            }
            else
            {
                Logger.Info(String.Format(CultureInfo.InvariantCulture, "[Response] [{0}] [{1}] {2}", actionExecutedContext.Request.Method.Method, actionExecutedContext.Request.RequestUri.ToString(), "Response is null"));
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}