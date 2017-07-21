﻿using MicroBotServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.DataLayer.Contracts
{
    public interface ILoginOperationsRepository
    {
        string GetHashPasswordByUserName(string userName);

        User GetUserDeatils(string userName);
    }
}