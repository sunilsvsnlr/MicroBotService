using MicroBotServices.Models.ValidationHelper;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Filters;

namespace MicroBotServices.WebAPI.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        static readonly Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Constructor
        /// </summary>
        public ExceptionHandlerFilterAttribute()
        {
            this.Mappings = new Dictionary<Type, HttpStatusCode>();
            this.Mappings.Add(typeof(EditException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(ArgumentNullException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(AggregateException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized);
            this.Mappings.Add(typeof(InvalidOperationException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(OutOfMemoryException), HttpStatusCode.RequestEntityTooLarge);
            this.Mappings.Add(typeof(NullReferenceException), HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Mappings
        /// </summary>
        public IDictionary<Type, HttpStatusCode> Mappings
        {
            get;
            private set;
        }

        /// <summary>
        /// Raises the exception event.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the action.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext != null && actionExecutedContext.Exception != null)
            {
                log.Error(actionExecutedContext.Exception);

                Exception exception = actionExecutedContext.Exception;
                if (this.Mappings.ContainsKey(exception.GetType()))
                {
                    var httpStatusCode = this.Mappings[exception.GetType()];
                    actionExecutedContext.Response = new HttpResponseMessage(httpStatusCode);
                    actionExecutedContext.Response.Content = new StringContent(Convert.ToString(exception.Message));
                }
                else
                {
                    actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    actionExecutedContext.Response.Content = new StringContent(Convert.ToString(exception.Message));
                }

                if (exception is EditException)
                {
                    actionExecutedContext.Response.Content = PopulateEditException(exception as EditException);
                }
            }
        }

        static HttpContent PopulateEditException(EditException exception)
        {
            if (exception == null)
            {
                return null;
            }
            var edits = exception.Edits;
            if (edits != null && edits.Count() > 0)
            {
                log.Error(JsonConvert.SerializeObject(edits));
                return new ObjectContent<IEnumerable<Edit>>(edits, new JsonMediaTypeFormatter());
            }
            else
            {
                log.Error(exception.Message);
                return new StringContent(exception.Message);
            }
        }
    }
}