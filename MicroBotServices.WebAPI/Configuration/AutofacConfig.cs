using Autofac;
using Autofac.Integration.WebApi;
using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.BusinessLayer.Security;
using MicroBotServices.BusinessLayer.Security;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace MicroBotServices.WebAPI.Configuration
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //register contracts with respective logic
            builder.RegisterType<LoginOperationsLogic>().As<ILoginOperationsLogic>().InstancePerRequest();
            builder.RegisterType<LoginOperationsRepository>().As<ILoginOperationsRepository>().InstancePerRequest();

            builder.RegisterType<MeetingRoomLogic>().As<IMeetingRoomLogic>().InstancePerRequest();
            builder.RegisterType<MeetingRoomRepository>().As<IMeetingRoomRepository>().InstancePerRequest();

            builder.RegisterType<CancelOperationLogic>().As<ICancelOperationLogic>().InstancePerRequest();
            builder.RegisterType<CancelRoomRepository>().As<ICancelRoomRepository>().InstancePerRequest();

            builder.RegisterType<BookingRoomOperationsLogic>().As<IBookingRoomOperationsLogic>().InstancePerRequest();
            builder.RegisterType<BookingRoomOperationsRepository>().As<IBookingRoomOperationsRepository>().InstancePerRequest();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}