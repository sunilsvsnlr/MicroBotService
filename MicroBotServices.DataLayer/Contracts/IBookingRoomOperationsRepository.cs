using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Contracts
{
    public interface IBookingRoomOperationsRepository
    {
        bool BookRoom(BookSchedule bookingRoom);
        bool CheckAvailability(BookSchedule bookingRoom);
    }
}
