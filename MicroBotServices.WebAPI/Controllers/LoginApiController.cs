using MicroBotServices.BusinessLayer.Contracts;
using MicroBotServices.WebAPI.Filters;
using MicroBotServices.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MicroBotServices.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class LoginApiController : ApiController
    {
        readonly ILoginOperationsLogic _LoginOperations;

        public LoginApiController(ILoginOperationsLogic loginOperations)
        {
            this._LoginOperations = loginOperations;
        }

        public User Get(string userName, string password)
        {
            return AutoMapper.Mapper.Map<User>(this._LoginOperations.GetUserDeatils(userName, password));
        }
    }
}