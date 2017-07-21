using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.Models.DomainModels
{
    public class BookSchedule
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string CreatedBy { get; set; }
        public int Location { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
