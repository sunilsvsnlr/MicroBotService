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
    public class BookingRoomOperationsRepository : Repository, IBookingRoomOperationsRepository
    {
        public bool BookRoom(BookSchedule bookingRoom)
        {
            return Create(Queries.BookSchedule.Bookroom(bookingRoom)) > 0;
        }

        public bool CheckAvailability(BookSchedule bookingRoom)
        {
            return GetCount(Queries.BookSchedule.CheckRoomAvailability(bookingRoom)) > 0;
        }
    }
}
