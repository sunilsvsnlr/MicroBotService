using MicroBotServices.DataLayer.Common;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.Models.DomainModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Repositories
{
    public class MeetingRoomRepository : Repository, IMeetingRoomRepository
    {
        public IEnumerable<MeetingRoom> GetAllMeetingRooms(string userName, DateTime startDate, DateTime endDate)
        {
            return GetAll(Queries.MeetingRoom.GetAllMeetingRooms(userName, startDate, endDate), GetAllMeetingRoomAction);
        }

        public void GetMeetingRoom(string userName, string meetingRoom, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeetingRoom> GetAllRoomDeatils()
        {
            return GetAll(Queries.MeetingRoom.GetAllRooms, GetAllMeetingRoomAction);
        }

        public IEnumerable<MeetingRoom> GetRoomByOrganizer(string userName)
        {
            return GetAll(Queries.MeetingRoom.GetRoomsByOrganizer(userName), GetAllMeetingRoomAction);
        }

        private static Action<MySqlDataReader, IList<MeetingRoom>> GetAllMeetingRoomAction
        {
            get
            {
                return (dr, meetingRooms) =>
                {
                    while (dr.Read())
                    {
                        var meetingRoom = new MeetingRoom()
                        {
                            RoomId = dr.GetInt32("id"),
                            AreaId = dr.GetInt32(dr.GetOrdinal("area_id")),
                            MeetingRoomName = dr.GetString("description"),
                            Start = dr.IsDBNull(dr.GetOrdinal("start_time")) ? (DateTime?)null : Utilities.UnixTimeStampToDateTime(dr.GetInt64("start_time")),
                            End = dr.IsDBNull(dr.GetOrdinal("end_time")) ? (DateTime?)null : Utilities.UnixTimeStampToDateTime(dr.GetInt64("end_time")),
                            Subject = dr.GetString("name"),
                            Location = dr.GetString(dr.GetOrdinal("area_name"))
                        };
                        meetingRooms.Add(meetingRoom);
                    }
                };

            }
        }
    }
}
