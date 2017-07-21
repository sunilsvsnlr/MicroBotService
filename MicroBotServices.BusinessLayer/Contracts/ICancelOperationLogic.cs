using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Contracts
{
    /// <summary>
    /// Cancel scheduled meeting intreface
    /// </summary>
    public interface ICancelOperationLogic
    {
        /// <summary>
        /// Cancels the meeting room.
        /// </summary>
        /// <param name="cancelRoom">The cancel room.</param>
        /// <returns></returns>
        string CancelMeetingRoom(CancelSchedule cancelRoom);
    }
}
