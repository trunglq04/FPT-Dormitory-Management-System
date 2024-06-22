using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;

namespace DMS_API.Helpers
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            this.CreateMap<Models.Domain.AppUser, Models.DTO.AppUserDTO>();

            CreateMap<Dorm, DormDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>().ReverseMap();
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
        }
    }
}
