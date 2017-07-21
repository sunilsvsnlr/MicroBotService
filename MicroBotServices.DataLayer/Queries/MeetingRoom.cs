using MicroBotServices.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Queries
{
    public static class MeetingRoom
    {
        public static string GetAllMeetingRooms(string userName, DateTime startDate, DateTime endDate)
        {
            return @"SELECT mrbs_room.id,mrbs_room.sort_key,mrbs_entry.start_time,mrbs_entry.end_time,mrbs_entry.description FROM mrbs_room ,mrbs_entry
                        WHERE mrbs_room.id not in (SELECT distinct room_id FROM mrbs_entry
                         where create_by = '" + userName + "' and start_time >= '" + Utilities.UnixTimeStamp(startDate) + "' and end_time<= '" + Utilities.UnixTimeStamp(endDate) + "')";
        }

        public const string GetAllRooms = @"SELECT 
                                                r.id,
                                                a.area_name,
                                                r.area_id,
                                                r.room_name,
                                                r.sort_key,
                                                r.description,
                                                r.capacity
                                            FROM
                                                mrbs.mrbs_room r,
                                                mrbs.mrbs_area a
                                            WHERE
                                                r.area_id = a.id
                                            ORDER BY area_id , id";

        public static string GetRoomsByOrganizer(string userName)
        {
            return string.Format(@"SELECT 
                                        r.id,
                                        r.area_id,
                                        r.room_name,
                                        e.start_time,
                                        e.end_time,
                                        e.name,
                                        r.description,
                                        a.area_name
                                    FROM
                                        mrbs_room r,
                                        mrbs_entry e,
                                        mrbs.mrbs_area a
                                    WHERE
                                        mrbs_entry.room_id = mrbs_room.id
                                            AND create_by = '{0}'", userName);
        }
    }
}
