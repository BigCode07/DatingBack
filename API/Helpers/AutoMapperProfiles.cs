using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Configuración de mapeo entre entidades y DTOs.
            CreateMap<AppUser, MemberDto>();
            CreateMap<Photo, PhotoDto>();   
        }
    }
}
