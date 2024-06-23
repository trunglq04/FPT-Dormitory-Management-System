using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Helpers
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<Models.Domain.AppUser, Models.DTO.AppUserDTO>();
            CreateMap<Dorm, DormDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>().ReverseMap();
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<AddFloorRequestDTO, Floor>().ReverseMap();
            CreateMap<UpdateFloorRequestDTO, Floor>().ReverseMap();
        }
    }
}
