using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Contracts
{
    public interface IMeetingRoomRepository
    {
        IEnumerable<MeetingRoom> GetAllMeetingRooms(string userName, DateTime startDate, DateTime endDate);

        void GetMeetingRoom(string userName, string meetingRoom, DateTime startDate, DateTime endDate);

        IEnumerable<MeetingRoom> GetAllRoomDeatils();

        IEnumerable<MeetingRoom> GetRoomByOrganizer(string userName);
    }
}
