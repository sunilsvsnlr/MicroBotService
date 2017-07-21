using MicroBotServices.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Queries
{
    class CancelSchedule
    {
        public static string CheckCancelRoomAvailability(Models.DomainModels.CancelSchedule cancelRoom)
        {
            return string.Format(@"select * from mrbs.mrbs_entry where room_id={0} and create_by = '{1}' and start_time = {2} and end_time={3}",
                cancelRoom.RoomId, cancelRoom.CreatedBy, Utilities.UnixTimeStamp(cancelRoom.StartTime), Utilities.UnixTimeStamp(cancelRoom.EndTime));
        }

        public static string CancelBookedRoom(Models.DomainModels.CancelSchedule cancelRoom)
        {
            return string.Format(@"delete from mrbs.mrbs_entry where room_id={0} and create_by = '{1}' and start_time = {2} and end_time={3}",
                cancelRoom.RoomId, cancelRoom.CreatedBy, Utilities.UnixTimeStamp(cancelRoom.StartTime), Utilities.UnixTimeStamp(cancelRoom.EndTime));
        }
       
    }
}
