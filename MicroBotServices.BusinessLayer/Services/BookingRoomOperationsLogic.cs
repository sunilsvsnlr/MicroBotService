using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.Models.DomainModels;
using MicroBotServices.Models.ValidationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Security
{
    /// <summary>
    /// To schedule meeting
    /// </summary>
    /// <seealso cref="MicroBotServices.BusinessLayer.Contracts.IBookingRoomOperationsLogic" />
    public class BookingRoomOperationsLogic : IBookingRoomOperationsLogic
    {
        readonly IBookingRoomOperationsRepository _BookingOperationsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRoomOperationsLogic"/> class.
        /// </summary>
        /// <param name="bookingOperationsRepository">The booking operations repository.</param>
        public BookingRoomOperationsLogic(IBookingRoomOperationsRepository bookingOperationsRepository)
        {
            this._BookingOperationsRepository = bookingOperationsRepository;
        }

        /// <summary>
        /// Bookings the room.
        /// </summary>
        /// <param name="bookingRoom">The booking room.</param>
        /// <returns></returns>
        public string BookingRoom(BookSchedule bookingRoom)
        {
            if (this._BookingOperationsRepository.CheckAvailability(bookingRoom))
            {
                return "Schedule already exists.";
            }
            else
            {
                return this._BookingOperationsRepository.BookRoom(bookingRoom) == true ? "Success" : "Failure";
            }

        }
    }
}
