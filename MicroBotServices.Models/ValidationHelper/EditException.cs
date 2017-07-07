using System;
using System.Collections.Generic;

namespace MicroBotServices.Models.ValidationHelper
{
    /// <summary>
    /// To show the custom exceptions
    /// </summary>
    [Serializable]
    public class EditException : Exception
    {
        /// <summary>
        /// List of edits
        /// </summary>
        /// TODO: Need to change the scope of this
        public IEnumerable<Edit> Edits { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EditException()
            : base()
        {
        }

        /// <summary>
        /// Constructor with edit message argument
        /// </summary>
        /// <param name="editMessage">editMessage</param>
        public EditException(string editMessage)
            : base(message: editMessage)
        {
        }

        /// <summary>
        /// Constructor with edit message and exception
        /// </summary>
        /// <param name="editMessage"></param>
        /// <param name="ex"></param>
        public EditException(string editMessage, Exception ex)
            : base(message: editMessage, innerException: ex)
        {
        }
    }
}
