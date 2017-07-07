using MicroBotServices.WebAPI.App_Start;
using MicroBotServices.WebAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MicroBotServices.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.Initialize();
            AutoMapperConfig.Configure();
        }
    }
}
