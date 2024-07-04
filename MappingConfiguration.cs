using AutoMapper;
using WebApplication8.Dtos;
using WebApplication8.Models.Login;

namespace WebApplication8
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserLoginDto>();
              //  .ForMember(user => user.Id, source => source.MapFrom(x => Guid.Parse(x.Id)));
              // en la linea 12, lo que hace es transformar el id del destino en un Guid...Preguntar..
            CreateMap<UserLoginDto, User>();
        }
    }
}
