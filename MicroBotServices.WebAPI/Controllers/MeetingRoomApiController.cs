using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.WebAPI.Filters;
using MicroBotServices.WebAPI.ViewModels;
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
    public class MeetingRoomApiController : ApiController
    {
        readonly IMeetingRoomLogic _MeetingRoomLogic;

        public MeetingRoomApiController(IMeetingRoomLogic meetingRoomLogic)
        {
            this._MeetingRoomLogic = meetingRoomLogic;
        }

        [HttpGet]
        public IEnumerable<MeetingRoom> Get(string userName, DateTime startDate, DateTime endDate)
        {
            return AutoMapper.Mapper.Map<IEnumerable<MeetingRoom>>(this._MeetingRoomLogic.GetAllMeetingRooms(userName, startDate, endDate));
        }

        [HttpGet]
        [ActionName("GetAllRoomDeatils")]
        public IEnumerable<MeetingRoom> GetAllRoomDeatils()
        {
            return AutoMapper.Mapper.Map<IEnumerable<MeetingRoom>>(this._MeetingRoomLogic.GetAllRoomDeatils());
        }

        [HttpGet]
        [ActionName("GetRoomsByEmployee")]
        public IEnumerable<MeetingRoom> GetRoomByOrganizer(string userName)
        {
            return AutoMapper.Mapper.Map<IEnumerable<MeetingRoom>>(this._MeetingRoomLogic.GetRoomByOrganizer(userName));
        }
    }
}