using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Door, DoorDTO>();
            CreateMap<User, UserInfoDTO>();

            CreateMap<DoorHistory, DoorHistoryDTO>()
            .ForMember(dest => dest.DoorName, opt => opt.MapFrom(src => src.Door != null ? src.Door.Name : null))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : null))
            .ForMember(dest => dest.ActionTypeDesc, opt => opt.MapFrom(src => ((DoorHistoryActionEnum)src.ActionType).ToString()));
        }
    }
}
