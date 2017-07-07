using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.Common
{
    /// <summary>
    /// This interface is supposed to be used on complex custom data type that is sensitive and needs to be masked. 
    /// </summary>
    public interface IComplexTypeCustomSerializer
    {
        /// <summary>
        /// Gets value to be logged for complex custom data types.
        /// </summary>
        /// <param name="regularExpression">The regular expression.</param>
        /// <returns></returns>
        string GetSerializedData(string regularExpression);
    }
}