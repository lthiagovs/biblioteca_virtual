using AutoMapper;
using VirtualLibrary.Domain.Dto.Person;
using VirtualLibrary.Domain.Models.Person;

namespace VirtualLibrary.Infrastructure.API.Mapper
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }

    }

}
