using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels = MicroBotServices.WebAPI.ViewModels;
using DomainModels = MicroBotServices.Models.DomainModels;

namespace MicroBotServices.WebAPI.App_Start.Profiles
{
    /// <summary>
    /// Auto mapper class for Micro Bot.
    /// </summary>
    public class MicroBotProfile : BaseProfile
    {
        protected override void CreateMaps()
        {
            //Create mappers here
            MapUserDomainModelToViewModel();
            MapMeetingRoomDomainModelToViewModel();
            MapRoomsDomainModelToViewModel();
            MapCancelRoomViewModelToDomainModel();
            MapCancelRoomDomainModelToViewModel();
            MapBookRoomViewModelToDomainModel();
            MapEmmployeeSheduledRoomDomainModelToViewModel();
        }

        private void MapMeetingRoomDomainModelToViewModel()
        {
            var userMap = CreateMap<DomainModels.MeetingRoom, ViewModels.MeetingRoom>();
            userMap.ForAllMembers(opt => opt.Ignore());
            userMap.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.MeetingRoomName, opt => opt.MapFrom(src => src.MeetingRoomName))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
        }

        private void MapUserDomainModelToViewModel()
        {
            var userMap = CreateMap<DomainModels.User, ViewModels.User>();
            userMap.ForAllMembers(opt => opt.Ignore());
            userMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }

        private void MapEmmployeeSheduledRoomDomainModelToViewModel()
        {
            var userMap = CreateMap<DomainModels.MeetingRoom, ViewModels.MeetingRoom>();
            userMap.ForAllMembers(opt => opt.Ignore());
            userMap.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.MeetingRoomName, opt => opt.MapFrom(src => src.MeetingRoomName));
        }

        private void MapRoomsDomainModelToViewModel()
        {
            var userMap = CreateMap<DomainModels.User, ViewModels.User>();
            userMap.ForAllMembers(opt => opt.Ignore());
            userMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<DomainModels.MeetingRoom, ViewModels.MeetingRoom>();

        }

        private void MapCancelRoomViewModelToDomainModel()
        {
            var cancelMap = CreateMap<DomainModels.CancelSchedule, ViewModels.CancelSchedule>();
            cancelMap.ForAllMembers(opt => opt.Ignore());
            cancelMap.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }

        private void MapCancelRoomDomainModelToViewModel()
        {
            var cancelMap = CreateMap<ViewModels.CancelSchedule, DomainModels.CancelSchedule>();
            cancelMap.ForAllMembers(opt => opt.Ignore());
            cancelMap.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId));
        }

        private void MapBookRoomViewModelToDomainModel()
        {
            var userMap = CreateMap<ViewModels.BookSchedule, DomainModels.BookSchedule>();
            userMap.ForAllMembers(opt => opt.Ignore());
            userMap.ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}