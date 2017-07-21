using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Contracts
{
    /// <summary>
    /// Interface to implement meeting rooms logic.
    /// </summary>
    public interface IMeetingRoomLogic
    {
        /// <summary>
        /// Gets all rooms.
        /// </summary>
        /// <returns></returns>
        IEnumerable<MeetingRoom> GetAllRoomDeatils();

        /// <summary>
        /// Gets the rooms by employee.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IEnumerable<MeetingRoom> GetRoomByOrganizer(string userName);
        
        /// <summary>
        /// Gets all meeting rooms.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        IEnumerable<MeetingRoom> GetAllMeetingRooms(string userName, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets the meeting room.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="meetingRoom">The meeting room.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        void GetMeetingRoom(string userName, string meetingRoom, DateTime startDate, DateTime endDate);
    }
}
