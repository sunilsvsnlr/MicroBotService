using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroBotServices.WebAPI.Common
{
    /// <summary>
    /// This interface is supposed to be used on complex data type that is sensitive and needs to be masked. 
    /// </summary>
    public interface ILogComplexType
    {
        /// <summary>
        /// Gets value to be logged for complex data types. 
        /// </summary>
        /// <returns>returns value</returns>
        string GetValueToBeLogged { get; }
    }
}