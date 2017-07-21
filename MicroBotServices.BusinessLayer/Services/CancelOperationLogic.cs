using MicroBotServices.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBotServices.DataLayer.Contracts;
using MicroBotServices.Models.DomainModels;

namespace MicroBotServices.BusinessLayer.Security
{
    /// <summary>
    /// To cancel the scheduled meeting logic
    /// </summary>
    /// <seealso cref="MicroBotServices.BusinessLayer.Contracts.ICancelOperationLogic" />
    public class CancelOperationLogic : ICancelOperationLogic
    {
        readonly ICancelRoomRepository _CancelRoomRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelOperationLogic"/> class.
        /// </summary>
        /// <param name="CancelRoomRepository">The cancel room repository.</param>
        public CancelOperationLogic(ICancelRoomRepository CancelRoomRepository)
        {
            this._CancelRoomRepository = CancelRoomRepository;
        }

        /// <summary>
        /// Cancels the meeting room.
        /// </summary>
        /// <param name="cancelRoom">The cancel room.</param>
        /// <returns></returns>
        public string CancelMeetingRoom(CancelSchedule cancelRoom)
        {
            return this._CancelRoomRepository.CancelRoom(cancelRoom);
        }
    }
}
