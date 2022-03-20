using AutoMapper;
using ClaySmartLock.DataAccess.Entity;
using ClaySmartLock.Model.DTO;
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
            CreateMap<DoorHistory, DoorHistoryDTO>();
            CreateMap<User, UserInfoDTO>();
        }
    }
}
