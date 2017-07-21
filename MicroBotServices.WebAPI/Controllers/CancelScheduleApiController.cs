using MicroBotServices.WebAPI.Filters;
using MicroBotServices.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MicroBotServices.WebAPI.ViewModels;

namespace MicroBotServices.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class CancelScheduleApiController : ApiController
    {
        readonly ICancelOperationLogic _cancelOperation;

        public CancelScheduleApiController(ICancelOperationLogic cancelOperation)
        {
            this._cancelOperation = cancelOperation;
        }

        [HttpDelete]
        public string CancelRoom([FromUri]CancelSchedule cancelSchedule)
        {
            if (cancelSchedule != null)
            {
                return this._cancelOperation.CancelMeetingRoom(AutoMapper.Mapper.Map<Models.DomainModels.CancelSchedule>(cancelSchedule));
            }
            return string.Empty;
        }
    }
}
