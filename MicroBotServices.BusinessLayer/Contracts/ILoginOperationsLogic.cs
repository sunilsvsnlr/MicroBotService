using MicroBotServices.Models.Common;
using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Contracts
{
    /// <summary>
    /// Interface to implement Login operations logic.
    /// </summary>
    public interface ILoginOperationsLogic
    {
        /// <summary>
        /// Validates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        TokenHolder Validate(string username, string password);

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        bool ValidateToken(string token);

        /// <summary>
        /// Decodes the token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        EmployeeToken DecodeToken(string token);

        /// <summary>
        /// Gets the user deatils.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        User GetUserDeatils(string userName, string password);

    }
}
