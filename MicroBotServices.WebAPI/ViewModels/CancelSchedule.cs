using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.ViewModels
{
    public class CancelSchedule
    {
        public string CreatedBy { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}