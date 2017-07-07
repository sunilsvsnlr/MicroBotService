using MicroBotServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.BusinessLayer.Contracts
{
    public interface ILoginOperations
    {
        TokenHolder Validate(string username, string password);
        bool ValidateToken(string token);
        EmployeeToken DecodeToken(string token);
    }
}
