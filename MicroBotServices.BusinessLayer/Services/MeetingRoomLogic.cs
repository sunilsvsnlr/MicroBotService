using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Security
{
    public class MeetingRoomLogic : IMeetingRoomLogic
    {
        readonly IMeetingRoomRepository _MeetingRoomRepository;

        public MeetingRoomLogic(IMeetingRoomRepository meetingRoomRepository)
        {
            this._MeetingRoomRepository = meetingRoomRepository;
        }

        public IEnumerable<MeetingRoom> GetAllMeetingRooms(string userName, DateTime startDate, DateTime endDate)
        {
            return this._MeetingRoomRepository.GetAllMeetingRooms(userName, startDate, endDate);
        }


        public void GetMeetingRoom(string userName, string meetingRoom, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeetingRoom> GetAllRoomDeatils()
        {
            return this._MeetingRoomRepository.GetAllRoomDeatils();
        }

        public IEnumerable<MeetingRoom> GetRoomByOrganizer(string userName)
        {
            return this._MeetingRoomRepository.GetRoomByOrganizer(userName);
        }
    }
}
