using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace MicroBotServices.WebAPI.App_Start.Profiles
{
    /// <summary>
    /// Base profile for automapper
    /// </summary>
    public abstract class BaseProfile : Profile
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        protected override void Configure()
        {
            CreateMaps();
        }

        /// <summary>
        /// Creates the maps.
        /// </summary>
        protected abstract void CreateMaps();
    }
}