using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.Models.DomainModels
{
    public class MeetingRoom
    {
        public int RoomId { get; set; }
        public int AreaId { get; set; }
        public string MeetingRoomName { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
    }
}
