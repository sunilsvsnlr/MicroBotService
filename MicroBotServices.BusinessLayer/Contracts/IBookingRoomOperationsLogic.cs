using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Contracts
{
    /// <summary>
    /// Booking room logic interface
    /// </summary>
    public interface IBookingRoomOperationsLogic
    {
        /// <summary>
        /// Bookings the room.
        /// </summary>
        /// <param name="bookingRoom">The booking room.</param>
        /// <returns></returns>
        string BookingRoom(BookSchedule bookingRoom);
    }
}
