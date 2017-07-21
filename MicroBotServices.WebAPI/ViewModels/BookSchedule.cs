using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.ViewModels
{
    public class BookSchedule
    {
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string CreatedBy { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        //public int Location { get; set; }
    }
}