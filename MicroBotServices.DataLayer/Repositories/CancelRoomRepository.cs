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
    public class CancelRoomRepository : ICancelRoomRepository
    {
        public string CancelRoom(CancelSchedule cancelRoom)
        {
            bool getroom = IsCancelRoomAvailable(cancelRoom);
            if (getroom)
            {
                return CancelBookedRoom(cancelRoom);
            }
            return string.Empty;
        }

        private string CancelBookedRoom(CancelSchedule cancelRoom)
        {
            MySqlConnection myConn = null;
            try
            {
                myConn = new MySqlConnection(Utilities.ConnectionString);
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.CancelSchedule.CancelBookedRoom(cancelRoom), myConn);
                int cancelledRoom = cmd.ExecuteNonQuery();
                if(cancelledRoom >0)
                {
                    return string.Format("Cancelled MeetingRoom {0} successfully",cancelRoom.RoomId);
                }
                return string.Empty;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }

        private bool IsCancelRoomAvailable(CancelSchedule cancelRoom)
        {
            try
            {
                var roomBooked = Repository.GetStringResult(Queries.CancelSchedule.CheckCancelRoomAvailability(cancelRoom));
                if(roomBooked!=null)
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            
        }
    }
}
