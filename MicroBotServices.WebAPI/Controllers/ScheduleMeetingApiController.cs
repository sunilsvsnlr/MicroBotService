using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MicroBotServices.WebAPI.ViewModels;

namespace MicroBotServices.WebAPI.Controllers
{
    [ExceptionHandlerFilterAttribute]
    public class ScheduleMeetingApiController : ApiController
    {
        readonly IBookingRoomOperationsLogic _BookingRoomDetails;

        public ScheduleMeetingApiController(IBookingRoomOperationsLogic bookingRoomData)
        {
            this._BookingRoomDetails = bookingRoomData;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] BookSchedule bookSchedule)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this._BookingRoomDetails.BookingRoom(AutoMapper.Mapper.Map<Models.DomainModels.BookSchedule>(bookSchedule)));
        }
    }
}
