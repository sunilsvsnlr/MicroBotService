using MicroBotServices.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.ViewModels
{
    public class MeetingRoom
    {
        public int RoomId { get; set; }
        public int AreaId { get; set; }
        public string MeetingRoomName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
    }
}