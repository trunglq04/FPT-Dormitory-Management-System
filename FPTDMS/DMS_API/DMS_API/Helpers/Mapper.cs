using AutoMapper;

namespace DMS_API.Helpers
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            this.CreateMap<Models.Domain.AppUser, Models.DTO.AppUserDTO>();

        }
    }
}
