using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AppUser, AppUserDTO>();
            

            //Domain to DTO and reverse
            CreateMap<Dorm, DormDTO>();
            CreateMap<Floor, FloorDTO>();
            CreateMap<House, HouseDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<AppUser, AppUserDTO>();
            CreateMap<Balance, BalanceDTO>();

            //Request DTOs
            CreateMap<AddFloorRequestDTO, Floor>();
            CreateMap<UpdateFloorRequestDTO, Floor>();
            CreateMap<AddHouseRequestDTO, House>();
            CreateMap<UpdateHouseRequestDTO, House>();
            CreateMap<UpdateUserRequestDTO, AppUser>();
        }
    }
}