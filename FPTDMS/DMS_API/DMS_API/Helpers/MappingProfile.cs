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
            //Domain to DTO
            CreateMap<Dorm, DormDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>().ReverseMap();
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();

            //Request DTOs
            CreateMap<AddFloorRequestDTO, Floor>().ReverseMap();
            CreateMap<UpdateFloorRequestDTO, Floor>().ReverseMap();
            CreateMap<AddHouseRequestDTO, House>().ReverseMap();
            CreateMap<UpdateHouseRequestDTO, House>().ReverseMap();
        }
    }
}
