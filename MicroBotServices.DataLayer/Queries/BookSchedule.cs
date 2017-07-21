using MicroBotServices.DataLayer.Common;
using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Queries
{
    class BookSchedule
    {
        public static string CheckRoomAvailability(Models.DomainModels.BookSchedule bookingRoom)
        {
            return string.Format(@"select count(*) from mrbs_entry where room_id={0} and ((start_time <= {1} and end_time > {1}) or (start_time < {2} and end_time >= {2})) ",
                bookingRoom.RoomId, Utilities.UnixTimeStamp(bookingRoom.StartDate), Utilities.UnixTimeStamp(bookingRoom.EndDate));
        }

        public static string Bookroom(Models.DomainModels.BookSchedule bookingRoom)
        {
             return string.Format(@"INSERT INTO mrbs_entry(start_time, end_time, entry_type, room_id, create_by, name, description,type) VALUES ({0},{1},{2},{3},'{4}','{5}','{6}','{7}')",
                 Utilities.UnixTimeStamp(bookingRoom.StartDate), Utilities.UnixTimeStamp(bookingRoom.EndDate), "0", bookingRoom.RoomId, bookingRoom.CreatedBy, bookingRoom.Subject, bookingRoom.Description,"I");
        }
    }
}
