using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.Models.ValidationHelper
{
    /// <summary>
    /// To show the custom exceptions
    /// </summary>
    public class Edit
    {
        /// <summary>
        /// Edit field name
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Edit exception message
        /// </summary>
        public string Message { get; set; }
    }
}
