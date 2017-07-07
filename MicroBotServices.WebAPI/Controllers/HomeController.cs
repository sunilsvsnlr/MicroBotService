using MicroBotServices.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MicroBotServices.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class HomeController : ApiController
    {
        [TraceLogActionFilter]
        public string Get()
        {
            return "Micro Bot Service is running.";
        }
    }
}
